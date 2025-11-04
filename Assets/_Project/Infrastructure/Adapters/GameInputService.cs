using Generated.Input;

namespace _Project.Infrastructure.Adapters
{
    public class GameInputService
    {
        private readonly PlayerControls _playerControls;

        public GameInputService(PlayerControls playerControls)
        {
            _playerControls = playerControls;
        }

        public void EnableGameplayInput() => _playerControls.Gameplay.Enable();
        public void DisableGameplayInput() => _playerControls.Gameplay.Disable();

        public void EnableUIInput() => _playerControls.UI.Enable();
        public void DisableUIInput() => _playerControls.UI.Disable();

        public void DisableAllInput()
        {
            DisableGameplayInput();
            DisableUIInput();
        }
    }
}