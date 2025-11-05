using _Project.Application.Interfaces;
using _Project.Infrastructure.Adapters;
using _Project.Presentation.Scripts.Controllers;
using _Project.Presentation.Scripts.UI;
using UnityEngine;

namespace _Project.Application.States.GameStates
{
    public class PlayingState : IGameState
    {
        private readonly UIRoot _uiRoot;
        private readonly GameInputService _inputService;
        private readonly GameWorld _gameWorld;

        public PlayingState(UIRoot uiRoot, GameInputService inputService, GameWorld gameWorld)
        {
            _uiRoot = uiRoot;
            _inputService = inputService;
            _gameWorld = gameWorld;
        }

        public void Enter()
        {
            Debug.Log("Entering Playing State");
            _uiRoot.HUDPanel.SetActive(true);
            _uiRoot.PauseMenuPanel.SetActive(false);
            _gameWorld.gameObject.SetActive(true);

            _inputService.EnableGameplayInput();
            _inputService.EnableUIInput();
            Time.timeScale = 1f;
        }

        public void Exit()
        {
            _inputService.DisableGameplayInput();
            Time.timeScale = 0f;
        }
    }
}