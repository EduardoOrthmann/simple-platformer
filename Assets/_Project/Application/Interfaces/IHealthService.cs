using _Project.Domain.Components;

namespace _Project.Application.Interfaces
{
    public interface IHealthService
    {
        void Heal(ref HealthComponent health, int amount);
        void Damage(ref HealthComponent health, int amount);
    }
}