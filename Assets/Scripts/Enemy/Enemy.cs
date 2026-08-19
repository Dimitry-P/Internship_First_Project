using Lesson.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private ICharacterHealth _characterHealth;

        [Inject]
        private void Construct(ICharacterHealth characterHealth)
        {
            _characterHealth = characterHealth;
        }

        private void Start()
        {
            _characterHealth.TakeDamage(2);
        }
    }
}
