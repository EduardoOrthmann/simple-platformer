using _Project.Application.States;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputState _input;
        private PlayerUseCase _useCase;
        private PlayerData _playerData;
        private Rigidbody2D _rb;

        [Inject]
        public void Construct(PlayerInputState input, PlayerUseCase useCase, PlayerData playerData)
        {
            _input = input;
            _useCase = useCase;
            _playerData = playerData;
        }

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            if (_input.Move != Vector2.zero)
                _useCase.MovePlayer(transform, _input.Move, _playerData.speed);

            if (_input.JumpPressed)
            {
                _useCase.Jump(_rb, _playerData.jumpForce);
                _input.JumpPressed = false;
            }

            _useCase.UpdateFallingState(_rb);
        }
    }
}