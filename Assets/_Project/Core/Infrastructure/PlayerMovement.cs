using UnityEngine;

namespace _Project.Core.Infrastructure
{
    public class PlayerMovement
    {
        private readonly PlayerInputState _inputState;
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed = 5f;

        public PlayerMovement(PlayerInputState inputState, Rigidbody2D rigidbody)
        {
            _inputState = inputState;
            _rigidbody = rigidbody;
        }

        public void Move()
        {
            _rigidbody.linearVelocityX = _inputState.MoveDirection.x * _speed;
        }
    }
}