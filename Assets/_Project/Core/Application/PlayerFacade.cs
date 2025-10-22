using _Project.Core.Domain;
using _Project.Core.Infrastructure;
using _Project.Presentation.Components;
using Zenject;

namespace _Project.Core.Application
{
    public class PlayerFacade : IFixedTickable
    {
        private readonly PlayerHealth _health;
        private readonly PlayerMovement _movement;
        private readonly PlayerView _view; // The MonoBehaviour in the scene

        // The PlayerView is injected from the scene via an installer binding
        public PlayerFacade(PlayerHealth health, PlayerMovement movement, PlayerView view)
        {
            _health = health;
            _movement = movement;
            _view = view;
        }

        // This is called by Zenject every FixedUpdate
        public void FixedTick()
        {
            _movement.Move();
        }

        public void TakeDamage(int amount)
        {
            _health.TakeDamage(amount);
        }
    }
}