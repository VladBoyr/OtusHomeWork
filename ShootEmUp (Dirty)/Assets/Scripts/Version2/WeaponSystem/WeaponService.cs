using UnityEngine;
using Version2.Common;
using Version2.Components;

namespace Version2.WeaponSystem
{
    public sealed class WeaponService
    {
        private readonly BulletService _bulletService;

        public WeaponService(BulletService bulletService)
        {
            this._bulletService = bulletService;
        }

        public void Fire(WeaponComponent weapon, BulletConfig config)
        {
            var teamComponent = weapon.GetComponent<TeamComponent>();
            if (teamComponent == null) return;

            var bulletLayer = teamComponent.IsPlayer
                ? PhysicsLayer.PlayerBullet
                : PhysicsLayer.EnemyBullet;

            var args = new BulletService.BulletArgs
            {
                Position = weapon.Position,
                Velocity = weapon.Rotation * Vector3.up * config.Speed,
                Color = config.Color,
                Damage = config.Damage,
                PhysicsLayer = (int)bulletLayer,
                IsPlayer = teamComponent.IsPlayer
            };
            this._bulletService.FlyBullet(args);
        }
    }
}