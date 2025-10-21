using Core.Infrastructure;
using Generated.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Presentation.Components
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
        }

        private void OnEnable() => _playerControls.Player.Enable();
        private void OnDisable() => _playerControls.Player.Disable();

        // This method is called by the Input System when the "Move" action is performed
        public void OnMove(InputAction.CallbackContext context)
        {
            _inputState.MoveDirection = context.ReadValue<Vector2>();
        }
    }
}