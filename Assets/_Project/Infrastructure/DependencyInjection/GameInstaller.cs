using _Project.Application.Commands;
using _Project.Application.Interfaces;
using _Project.Application.States;
using _Project.Application.States.GameStates;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using _Project.Infrastructure.Adapters;
using _Project.Infrastructure.Services;
using _Project.Presentation.Scripts.Controllers;
using _Project.Presentation.Scripts.States;
using _Project.Presentation.Scripts.UI;
using Generated.Input;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure.DependencyInjection
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private UIRoot uiRootInstance;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle();
            Container.Bind<PlayerState>().AsSingle();

            Container.Bind<IMovementService>().To<MovementService>().AsSingle();
            Container.Bind<IHealthService>().To<HealthService>().AsSingle();

            Container.Bind<PlayerData>().FromInstance(playerData).AsSingle();
            Container.Bind<PlayerUseCase>().AsTransient();

            Container.Bind<PlayerAnimationState>().AsSingle();

            Container.Bind<CommandProcessor>().AsSingle();
            Container.BindFactory<Transform, Vector2, MoveCommand, MoveCommand.Factory>();
            Container.BindFactory<Rigidbody2D, JumpCommand, JumpCommand.Factory>();

            Container.Bind<PlayerControls>().AsSingle().NonLazy();
            Container.Bind<GameInputService>().AsSingle();

            // UI Views
            Container.Bind<GameWorld>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();

            Container.Bind<UIRoot>().FromInstance(uiRootInstance).AsSingle();
            Container.Bind<HealthBarView>().FromInstance(uiRootInstance.GetComponentInChildren<HealthBarView>()).AsSingle();

            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<IGameState>().To<MainMenuState>().AsSingle();
            Container.Bind<IGameState>().To<PlayingState>().AsSingle();
            Container.Bind<IGameState>().To<PausedState>().AsSingle();

            Container.Bind<GameController>().FromComponentInHierarchy().AsSingle();
        }
    }
}