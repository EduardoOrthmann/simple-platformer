using System;
using _Project.Application.Interfaces;
using _Project.Domain.Components;

namespace _Project.Infrastructure.Services
{
    public class HealthService : IHealthService
    {
        public void Damage(ref HealthComponent health, int amount) =>
            health.current = Math.Max(health.current - amount, 0);
    }
}