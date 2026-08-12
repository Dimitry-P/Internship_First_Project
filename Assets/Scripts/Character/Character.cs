using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson.DI
{
    public class Character
    {
        private readonly ICharacterHealth _characterHealth;

        public Character(ICharacterHealth characterHealth)
        {
            _characterHealth = characterHealth;
        }

        public void Hit()
        {
            _characterHealth.TakeDamage(30);
        }
    }
}
