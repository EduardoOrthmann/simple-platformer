using _Project.Core.Shared;
using Zenject;

namespace _Project.Core.Domain
{
    public class PlayerHealth
    {
        private readonly SignalBus _signalBus;
        private int CurrentHealth { get; set; }

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