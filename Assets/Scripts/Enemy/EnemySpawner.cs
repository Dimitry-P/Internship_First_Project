using Lesson.DI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;

        private IObjectResolver _objectResolver;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void Spawn()
        {
            Enemy enemy = Instantiate(enemyPrefab);
            _objectResolver.Inject(enemy);
            Character character = _objectResolver.Resolve<Character>();
            character.Hit();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Spawn();
            }
        }
    }
}
