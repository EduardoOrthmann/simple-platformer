using _Project.Application.UseCases;
using _Project.Domain.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Application.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly PlayerUseCase _useCase;
        private readonly Transform _transform;
        private readonly Vector2 _input;
        private readonly float _speed;

        public class Factory : PlaceholderFactory<Transform, Vector2, MoveCommand> {}

        [Inject]
        public MoveCommand(
            Transform transform,
            Vector2 input,
            PlayerUseCase useCase,
            PlayerData playerData)
        {
            _transform = transform;
            _input = input;
            _useCase = useCase;
            _speed = playerData.speed;
        }

        public bool IsValid() => true;

        public void Execute()
        {
            _useCase.MovePlayer(_transform, _input, _speed);
        }
    }
}