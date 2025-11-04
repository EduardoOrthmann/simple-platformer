using _Project.Application.States;
using _Project.Application.States.GameStates;
using _Project.Presentation.Scripts.UI;
using Generated.Input;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private UIRoot _uiRoot;
        private PlayerControls _playerControls;

        [Inject]
        public void Construct(
            GameStateMachine gameStateMachine,
            UIRoot uiRoot,
            PlayerControls playerControls)
        {
            _gameStateMachine = gameStateMachine;
            _uiRoot = uiRoot;
            _playerControls = playerControls;
        }

        private void Start()
        {
            _uiRoot.StartButton.onClick.AddListener(OnStartGame);
            _uiRoot.ResumeButton.onClick.AddListener(OnResumeGame);
            _uiRoot.QuitToMenuButton.onClick.AddListener(OnQuitToMenu);

            _playerControls.UI.Pause.performed += _ => OnPause();

            // Start the game in the main menu
            _gameStateMachine.ChangeState(typeof(MainMenuState));
        }

        private void OnDestroy()
        {
            _uiRoot.StartButton.onClick.RemoveListener(OnStartGame);
            _uiRoot.ResumeButton.onClick.RemoveListener(OnResumeGame);
            _uiRoot.QuitToMenuButton.onClick.RemoveListener(OnQuitToMenu);
        }

        private void OnStartGame() => _gameStateMachine.ChangeState(typeof(PlayingState));
        private void OnResumeGame() => _gameStateMachine.ChangeState(typeof(PlayingState));
        private void OnQuitToMenu() => _gameStateMachine.ChangeState(typeof(MainMenuState));
        private void OnPause() => _gameStateMachine.TogglePause();
    }
}