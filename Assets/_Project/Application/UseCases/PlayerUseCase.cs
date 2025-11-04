using _Project.Application.Interfaces;
using _Project.Application.States;
using _Project.Domain.Components;
using UnityEngine;

namespace _Project.Application.UseCases
{
    public class PlayerUseCase
    {
        private readonly IMovementService _movement;
        private readonly IHealthService _health;
        private readonly PlayerState _playerState;

        public PlayerUseCase(
            IMovementService movement,
            IHealthService health,
            PlayerState playerState)
        {
            _movement = movement;
            _health = health;
            _playerState = playerState;
        }

        public void MovePlayer(Transform transform, Vector2 input, float speed)
        {
            _movement.Move(transform, input, speed);
            _playerState.IsRunning = input != Vector2.zero;
        }

        public void Jump(Rigidbody2D rb, float jumpForce)
        {
            if (!_playerState.IsGrounded) return;

            _movement.Jump(rb, jumpForce);
            _playerState.IsJumping = true;
        }

        public void UpdateJumpAndFallState(Rigidbody2D rb)
        {
            _playerState.IsFalling = rb.linearVelocityY < -0.01f;

            if (_playerState.IsJumping && _playerState.IsFalling)
                _playerState.IsJumping = false;
        }

        public void Damage(ref HealthComponent healthComponent, int amount)
            => _health.Damage(ref healthComponent, amount);
    }
}