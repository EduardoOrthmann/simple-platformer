using _Project.Domain.Components;

namespace _Project.Application.Interfaces
{
    public interface IHealthService
    {
        void Damage(ref HealthComponent health, int amount);
    }
}