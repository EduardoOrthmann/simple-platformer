using UnityEngine;

namespace Core.Infrastructure
{
    public class PlayerMovement
    {
        private readonly PlayerInputState _inputState;
        private readonly Rigidbody2D _rigidbody;
        // We'd inject a PlayerConfig ScriptableObject here for speed, etc.
        private readonly float _speed = 5f;

        public PlayerMovement(PlayerInputState inputState, Rigidbody2D rigidbody)
        {
            _inputState = inputState;
            _rigidbody = rigidbody;
        }

        public void Move()
        {
            _rigidbody.linearVelocity = _inputState.MoveDirection.normalized * _speed;
        }
    }
}