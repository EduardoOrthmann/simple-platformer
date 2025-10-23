using _Project.Core.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure.Bootstrap
{
    public class GameBootstrap : IInitializable
    {
        private readonly PlayerFactory _playerFactory;
        private readonly Transform _spawnPoint;

        public GameBootstrap(PlayerFactory playerFactory, [Inject(Id = "SpawnPoint")] Transform spawnPoint)
        {
            _playerFactory = playerFactory;
            _spawnPoint = spawnPoint;
        }

        public void Initialize()
        {
            _playerFactory.Create(_spawnPoint.position);
        }
    }
}