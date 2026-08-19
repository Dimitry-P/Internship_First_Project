using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lesson.DI
{
    //Здесь ментор сделал очень важный архитектурный шаг: он убрал MonoBehaviour из GameInit
    //и превратил этот класс в точку входа VContainer через IStartable.
    public class GameInit : IStartable
    {
        private Character _character;

        public GameInit(Character character)
        {
            _character = character;
        }
      
        public void Start()
        {
            _character.Hit();
            _character.Hit();
        }
    }
}
