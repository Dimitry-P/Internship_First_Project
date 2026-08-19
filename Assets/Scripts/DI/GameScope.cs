using UnityEngine;
using VContainer;
using VContainer.Unity;
using static UnityEditor.ObjectChangeEventStream;


//Данный класс нужен, чтобы все регистрации зависимостей можно было собрать в одном понятном месте.
//И этот класс становится примерно таким: «Вот конфигурация зависимостей моей игры».
namespace Lesson.DI
{
    public class GameScope : LifetimeScope
    //LifetimeScope — это готовый класс VContainer, который представляет область действия DI-контейнера и является точкой, где этот контейнер настраивается и создаётся.
    //2. А зачем нам вообще GameScope?
    //Вот здесь самое главное.
    //Нам нужно где-то сказать VContainer, какие зависимости существуют в нашей игре.
    //Например, у нас есть: CharacterHealth
    //и мы хотим сказать:
    //«VContainer, вот этот класс CharacterHealth нужно зарегистрировать в контейнере».
    //Для этого нам нужно место, где будут находиться такие инструкции.
    //И вот GameScope как раз становится местом настройки нашего контейнера.

    //    Почему именно наследование?
    //VContainer уже написал большой готовый класс:
    //LifetimeScope
    //Внутри него реализована вся инфраструктура, необходимая для работы scope:
    //    создание контейнера;
    //    запуск его построения;
    //    управление временем жизни зарегистрированных объектов;
    //    связь с Unity;
    //    создание дочерних scope и т.д.
    //А тебе НЕ нужно писать всё это самому.
    //Ты просто наследуешься -- public class GameScope : LifetimeScope и получаешь эту функциональность.
    //LifetimeScope — готовая инфраструктура VContainer, GameScope — твоя конкретная конфигурация.
    {
        protected override void Configure(IContainerBuilder builder) //builder — это объект, с помощью которого мы настраиваем контейнер.
        {
            builder.Register<CharacterHealth>(Lifetime.Singleton)
                .As<ICharacterHealth>();
            //Можно буквально читать:
            //«Builder, зарегистрируй CharacterHealth в контейнере с временем жизни Singleton».
            //То есть builder — это строитель/ настройщик контейнера.
            builder.Register<Character>(Lifetime.Singleton);
            //И здесь не нужно добавлять:  .As<ICharacterHealth>()
            //потому что Character не является реализацией ICharacterHealth.

            //Эти две записи можно прочитать человеческим языком:
            //Первая:
            //«VContainer, если кто-то попросит ICharacterHealth, предоставь ему CharacterHealth.»
            //Вторая:
            //«VContainer, если кто-то попросит Character, предоставь ему Character.»

            //РЕГИСТРИРУЮ КАК ТОЧКУ ВХОДА В ПРОГРАММУ!!!!!!!!!!!
            builder.RegisterEntryPoint<GameInit>();
        }
    }
    //!!!!!!!!!!!!!!ОЧЕНЬ важная вещь именно для Unity!!!!!!!!!!!!!!!!
    //GameScope — это обычный C#-класс, но поскольку он наследуется от: LifetimeScope
    //он становится компонентом/точкой входа VContainer, которую можно использовать в Unity.

    //Обычно ты создаёшь объект в сцене: GameScope и добавляешь на него компонент GameScope.
    //При запуске сцены VContainer видит этот LifetimeScope, вызывает его конфигурацию:
    //    Configure(builder)
    //а внутри неё ты регистрируешь свои зависимости.
}
