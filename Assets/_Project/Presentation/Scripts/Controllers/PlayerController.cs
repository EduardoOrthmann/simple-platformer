using _Project.Application.States;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputState _input;
        private PlayerUseCase _useCase;
        private PlayerData _playerData;
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;

        [Inject]
        public void Construct(PlayerInputState input, PlayerUseCase useCase, PlayerData playerData)
        {
            _input = input;
            _useCase = useCase;
            _playerData = playerData;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            _useCase.MovePlayer(transform, _input.Move, _playerData.speed);

            if (Mathf.Abs(_input.Move.x) > 0.01f) _spriteRenderer.flipX = _input.Move.x < 0;

            if (_input.JumpPressed)
            {
                _useCase.Jump(_rb, _playerData.jumpForce);
                _input.JumpPressed = false;
            }

            _useCase.UpdateJumpAndFallState(_rb);
        }
    }
}