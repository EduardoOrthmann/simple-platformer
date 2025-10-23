using _Project.Presentation.Actors;
using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure.Factories
{
    public class PlayerFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;

        public PlayerFactory(DiContainer container, GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        public PlayerActor Create(Vector3 position)
        {
            return _container.InstantiatePrefabForComponent<PlayerActor>(_playerPrefab, position, Quaternion.identity,
                null);
        }
    }
}