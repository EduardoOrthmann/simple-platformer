using _Project.Core.Infrastructure;
using Zenject;

namespace _Project.Core.Application
{
    public class PlayerFacade : IFixedTickable
    {
        private readonly PlayerMovement _movement;

        public PlayerFacade(PlayerMovement movement)
        {
            _movement = movement;
        }

        public void FixedTick()
        {
            _movement.Move();
        }
    }
}