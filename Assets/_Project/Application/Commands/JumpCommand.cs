using _Project.Application.States;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Application.Commands
{
    public class JumpCommand : ICommand
    {
        private readonly PlayerUseCase _useCase;
        private readonly PlayerState _playerState;
        private readonly Rigidbody2D _rb;
        private readonly float _jumpForce;

        public class Factory : PlaceholderFactory<Rigidbody2D, JumpCommand> {}

        [Inject]
        public JumpCommand(Rigidbody2D rb, PlayerUseCase useCase, PlayerState playerState, PlayerData playerData)
        {
            _rb = rb;
            _useCase = useCase;
            _playerState = playerState;
            _jumpForce = playerData.jumpForce;
        }

        public bool IsValid()
        {
            return _playerState.IsGrounded;
        }

        public void Execute()
        {
            _useCase.Jump(_rb, _jumpForce);
        }
    }
}