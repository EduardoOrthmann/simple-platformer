using _Project.Core.Domain.Components;
using Zenject;

namespace _Project.Core.Domain.Entities
{
    public class PlayerEntity
    {
        public MovementData Movement { get; private set; }
        public HealthData Health { get; private set; }

        public PlayerEntity(MovementData movement, HealthData health)
        {
            Movement = movement;
            Health = health;
        }

        public class Factory : PlaceholderFactory<MovementData, HealthData, PlayerEntity> { }
    }
}