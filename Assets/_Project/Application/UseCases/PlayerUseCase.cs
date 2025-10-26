using _Project.Application.Interfaces;
using _Project.Application.States;
using _Project.Domain.Components;
using _Project.Domain.Entities;
using UnityEngine;

namespace _Project.Application.UseCases
{
    public class PlayerUseCase
    {
        private readonly IMovementService _movement;
        private readonly IWeaponService _weapon;
        private readonly IHealthService _health;
        private readonly PlayerState _playerState;

        public PlayerUseCase(
            IMovementService movement,
            IWeaponService weapon,
            IHealthService health,
            PlayerState playerState)
        {
            _movement = movement;
            _weapon = weapon;
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

        public void UpdateFallingState(Rigidbody2D rb)
        {
            _playerState.IsFalling = rb.linearVelocityY < -0.01f;

            if (_playerState.IsJumping && _playerState.IsFalling)
                _playerState.IsJumping = false;

            _playerState.IsGrounded = Mathf.Abs(rb.linearVelocityY) < 0.1f;
        }

        public void Shoot(Transform transform, Weapon weaponData)
            => _weapon.TryShoot(transform, weaponData);

        public void Heal(ref HealthComponent healthComponent, int amount)
            => _health.Heal(ref healthComponent, amount);
    }
}