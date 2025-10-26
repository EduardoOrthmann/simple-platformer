using _Project.Application.Interfaces;
using _Project.Domain.Entities;
using UnityEngine;

namespace _Project.Infrastructure.Services
{
    public class WeaponService : IWeaponService
    {
        private float _nextShootTime;

        public void TryShoot(Transform shooter, Weapon weapon)
        {
            if (Time.time < _nextShootTime) return;

            var bulletPrefab = Resources.Load<GameObject>("Bullet");
            var bullet = Object.Instantiate(bulletPrefab, shooter.position, shooter.rotation);

            var bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = shooter.up * 10f;

            _nextShootTime = Time.time + weapon.shootCooldown;
        }
    }
}