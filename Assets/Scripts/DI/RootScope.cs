using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("RootScope started");
    }
}
//глобальный контейнер - создаю прессет
// Зависимости не теряются при переходе из сцены в сцену. Добавил скрипт RootScope/
// После запуска игры RootScope появился раньше чем мы получили какие-то другие зависимости.
// Файлы которые переносятся между сценами - их удобно добавить дочерними объектами в RootScope
// и эти объекты будут висеть у меня в DontDestroyOnLoad.
// RootScope — глобальная область DI-контейнера, которая может содержать зависимости с lifetime Singleton,
// а сам RootScope сохраняется между сценами.
// Добавил префабы:  Enemy и RootScope.   Создал специальный объект который будет инстанциировать через контейнер.
// Получил зависимость на objectResolver через контейнер.    