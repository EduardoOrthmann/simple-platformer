using _Project.Application.Commands;
using _Project.Application.Interfaces;
using _Project.Application.States;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using _Project.Infrastructure.Services;
using _Project.Presentation.Scripts.States;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure.DependencyInjection
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;

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
        }
    }
}