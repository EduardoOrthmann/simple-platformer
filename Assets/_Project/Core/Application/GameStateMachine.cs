using Core.Shared;
using Zenject;

namespace Core.Application
{
    public class GameStateMachine
    {
        public GameStateMachine(SignalBus signalBus)
        {
            // Subscribe to the signal
            signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        }

        private void OnPlayerDied()
        {
            // Logic to switch to a GameOverState, show a menu, etc.
            UnityEngine.Debug.Log("Game Over! The state machine has been notified.");
        }
    }
}