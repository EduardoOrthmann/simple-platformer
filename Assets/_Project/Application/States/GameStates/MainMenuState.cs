using _Project.Application.Interfaces;
using _Project.Infrastructure.Adapters;
using _Project.Presentation.Scripts.Controllers;
using _Project.Presentation.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Application.States.GameStates
{
    public class MainMenuState : IGameState
    {
        private readonly UIRoot _uiRoot;
        private readonly GameInputService _inputService;
        private readonly GameWorld _gameWorld;

        public MainMenuState(UIRoot uiRoot, GameInputService inputService, GameWorld gameWorld)
        {
            _uiRoot = uiRoot;
            _inputService = inputService;
            _gameWorld = gameWorld;
        }

        public void Enter()
        {
            Debug.Log("Entering Main Menu State");
            _uiRoot.MainMenuPanel.SetActive(true);
            _uiRoot.HUDPanel.SetActive(false);
            _uiRoot.PauseMenuPanel.SetActive(false);
            _gameWorld.gameObject.SetActive(false);

            _inputService.DisableGameplayInput();
            _inputService.EnableUIInput();

            Time.timeScale = 1f;
        }

        public void Exit()
        {
            Debug.Log("Exiting Main Menu State");
            _uiRoot.MainMenuPanel.SetActive(false);
        }
    }
}