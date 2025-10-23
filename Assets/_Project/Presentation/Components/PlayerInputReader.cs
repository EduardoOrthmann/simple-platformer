using _Project.Core.Infrastructure;
using Generated.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Presentation.Components
{
    public class PlayerInputReader : MonoBehaviour, PlayerControls.IPlayerActions
    {
        private PlayerInputState _inputState;
        private PlayerControls _playerControls;

        [Inject]
        public void Construct(PlayerInputState inputState)
        {
            _inputState = inputState;
        }

        private void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Player.SetCallbacks(this);
            _playerControls.Player.Enable();
        }

        private void OnDisable() => _playerControls.Disable();

        public void OnMove(InputAction.CallbackContext context)
        {
            _inputState.Move = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            _inputState.JumpPressed = context.started;
        }
    }
}