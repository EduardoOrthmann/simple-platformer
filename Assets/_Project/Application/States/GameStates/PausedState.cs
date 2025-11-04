using _Project.Application.Interfaces;
using _Project.Presentation.Scripts.UI;

namespace _Project.Application.States.GameStates
{
    public class PausedState : IGameState
    {
        private readonly UIRoot _uiRoot;

        public PausedState(UIRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public void Enter()
        {
            _uiRoot.PauseMenuPanel.SetActive(true);
        }

        public void Exit()
        {
            _uiRoot.PauseMenuPanel.SetActive(false);
        }
    }
}