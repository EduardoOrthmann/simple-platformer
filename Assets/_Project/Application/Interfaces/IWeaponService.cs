using _Project.Domain.Entities;
using UnityEngine;

namespace _Project.Application.Interfaces
{
    public interface IWeaponService
    {
        void TryShoot(Transform shooter, Weapon weapon);
    }
}