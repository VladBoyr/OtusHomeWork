using Common;
using Components;
using UnityEngine;

namespace WeaponSystem
{
    public sealed class WeaponService
    {
        private readonly BulletService _bulletService;

        public WeaponService(BulletService bulletService)
        {
            this._bulletService = bulletService;
        }

        public void Fire(WeaponComponent weapon, BulletConfig config, Vector2 targetDirection)
        {
            var teamComponent = weapon.GetComponent<TeamComponent>();
            if (teamComponent == null) return;

            var bulletLayer = teamComponent.IsPlayer
                ? PhysicsLayer.PlayerBullet
                : PhysicsLayer.EnemyBullet;

            var args = new BulletService.BulletArgs
            {
                Position = weapon.Position,
                Velocity = weapon.Rotation * targetDirection * config.Speed,
                Color = config.Color,
                Damage = config.Damage,
                PhysicsLayer = (int)bulletLayer,
                IsPlayer = teamComponent.IsPlayer
            };
            this._bulletService.FlyBullet(args);
        }
    }
}