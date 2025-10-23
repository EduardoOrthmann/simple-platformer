using _Project.Core.Application.Facades;
using _Project.Core.Application.Services;
using _Project.Core.Domain.Components;
using _Project.Core.Domain.Entities;
using _Project.Core.Infrastructure;
using _Project.Core.Infrastructure.Bootstrap;
using _Project.Core.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform spawnPoint;

        public override void InstallBindings()
        {
            // Domain Entities
            Container.Bind<PlayerEntity>().AsSingle();

            // Infrastructure
            Container.Bind<PlayerInputState>().AsSingle();
            Container.BindInstance(playerPrefab).WhenInjectedInto<PlayerFactory>();
            Container.Bind<PlayerFactory>().AsSingle();

            // Application Services
            Container.Bind<MovementService>().AsSingle();
            Container.Bind<HealthService>().AsSingle();

            // Presentation
            Container.BindInstance(spawnPoint).WithId("SpawnPoint");
            Container.BindFactory<MovementData, HealthData, PlayerEntity, PlayerEntity.Factory>().AsTransient();

            // Bootstrap
            Container.BindInterfacesTo<GameBootstrap>().AsSingle();
        }
    }
}