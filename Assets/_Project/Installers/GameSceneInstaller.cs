using _Project.Core.Application;
using _Project.Core.Domain;
using _Project.Core.Infrastructure;
using _Project.Core.Shared;
using _Project.Presentation.Components;
using _Project.Presentation.ViewModels;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private GameObject enemyPrefab;

        public override void InstallBindings()
        {
            // 1. Core Systems (Singletons)
            Container.Bind<ScoreManager>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveSpawner>().AsSingle(); // Needs ITickable

            // 2. Player Systems (Singletons for a single-player game)
            Container.Bind<PlayerInputState>().AsSingle(); // A POCO to hold input values
            Container.Bind<PlayerHealth>().AsSingle().WithArguments(100); // Start with 100 health
            Container.Bind<PlayerMovement>().AsSingle();
            Container.Bind<PlayerView>().FromComponentOn(playerGameObject).AsSingle();
            // Bind the Rigidbody2D component from the player object in the scene
            Container.Bind<Rigidbody2D>().FromInstance(playerGameObject.GetComponent<Rigidbody2D>()).AsSingle();
            // Bind PlayerFacade to IFixedTickable so Zenject calls its FixedTick()
            Container.BindInterfacesAndSelfTo<PlayerFacade>().AsSingle();

            // 3. UI (MVP Pattern)
            // The View is in the scene, so we bind the instance.
            Container.Bind<IHUDView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HUDPresenter>().AsSingle().NonLazy(); // NonLazy to start listening immediately

            // 4. Factories (Factory Pattern)
            // We'll define the Enemy.Factory later
            Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(enemyPrefab).AsSingle();

            // ... (Signal bindings are the same) ...
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerDiedSignal>();
            Container.DeclareSignal<EnemyDestroyedSignal>();
            Container.DeclareSignal<ScoreUpdatedSignal>();
        }
    }
}