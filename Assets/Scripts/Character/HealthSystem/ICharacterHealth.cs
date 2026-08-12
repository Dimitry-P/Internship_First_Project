namespace Lesson.DI
{
    public interface ICharacterHealth
    {
        int CurrentHealth { get; }
        void TakeDamage(int damage);
    }
}

