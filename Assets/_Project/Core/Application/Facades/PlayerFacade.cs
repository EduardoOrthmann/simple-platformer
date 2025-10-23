using _Project.Core.Application.Services;
using _Project.Core.Domain.Entities;
using _Project.Core.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Project.Core.Application.Facades
{
    public class PlayerFacade : IFixedTickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly PlayerEntity _entity;
        private readonly PlayerInputState _input;
        private readonly MovementService _movement;
        private readonly HealthService _health;

        // If there are more services, consider using a record to PlayerContext to group them.
        [Inject]
        public PlayerFacade(
            PlayerEntity entity,
            PlayerInputState input,
            MovementService movement,
            HealthService health,
            Rigidbody2D rigidbody)
        {
            _entity = entity;
            _input = input;
            _movement = movement;
            _health = health;
            _rigidbody = rigidbody;
        }

        public void FixedTick()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            _movement.Move(_rigidbody, _entity.Movement, _input.Move.x);

            if (_input.JumpPressed)
            {
                _movement.Jump(_rigidbody, _entity.Movement);
                _input.JumpPressed = false;
            }
        }
    }
}