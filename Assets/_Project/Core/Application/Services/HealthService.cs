using _Project.Core.Domain.Components;
using UnityEngine;

namespace _Project.Core.Application.Services
{
    public class HealthService
    {
        public void TakeDamage(HealthData data, int amount)
        {
            data.currentHealth = Mathf.Max(0, data.currentHealth - amount);
        }

        public void Heal(HealthData data, int amount)
        {
            data.currentHealth = Mathf.Min(data.maxHealth, data.currentHealth + amount);
        }
    }
}