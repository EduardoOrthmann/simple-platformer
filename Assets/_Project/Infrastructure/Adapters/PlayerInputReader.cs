using _Project.Application.States;
using Generated.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Infrastructure.Adapters
{
    public class PlayerInputReader : MonoBehaviour, PlayerControls.IGameplayActions
    {
        private PlayerControls _controls;
        private PlayerInputState _inputState;

        [Inject]
        public void Construct(PlayerInputState state)
        {
            _inputState = state;
            _controls = new PlayerControls();
            _controls.Gameplay.SetCallbacks(this);
            _controls.Enable();
        }

        public void OnMove(InputAction.CallbackContext ctx)
        {
            _inputState.Move = ctx.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
                _inputState.JumpPressed = true;
        }
    }
}