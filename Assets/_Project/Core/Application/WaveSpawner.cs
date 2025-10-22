using _Project.Presentation.Components;
using Zenject;

namespace _Project.Core.Application
{
    public class WaveSpawner : ITickable
    {
        // Zenject provides a concrete factory that knows about the prefab
        private readonly Enemy.Factory _enemyFactory;

        public WaveSpawner(Enemy.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Tick()
        {
            // Simplified spawn logic: spawn one enemy every 5 seconds
            if (UnityEngine.Time.frameCount % 300 == 0)
            {
                // SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            _enemyFactory.Create();
            UnityEngine.Debug.Log("Spawner asked Factory to create an Enemy.");
        }
    }
}