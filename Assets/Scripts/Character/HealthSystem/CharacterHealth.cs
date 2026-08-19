using UnityEngine;

namespace Lesson.DI
{
    public class CharacterHealth : ICharacterHealth
    {
        public int CurrentHealth { get; private set; } = 100;
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            Debug.Log($"Character has been hit for {damage} damage." + $"Current Health: {CurrentHealth}");
        }
    }
}

