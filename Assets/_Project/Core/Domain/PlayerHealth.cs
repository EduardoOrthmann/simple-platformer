using Core.Shared;
using Zenject;

namespace Core.Application.Player
{
    public class PlayerHealth
    {
        private readonly SignalBus _signalBus;
        public int CurrentHealth { get; private set; }

        public PlayerHealth(int startingHealth, SignalBus signalBus)
        {
            CurrentHealth = startingHealth;
            _signalBus = signalBus;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                _signalBus.Fire<PlayerDiedSignal>(); // Announce death!
            }
        }
    }
}