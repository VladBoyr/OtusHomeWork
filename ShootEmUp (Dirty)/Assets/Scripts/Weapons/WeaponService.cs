using System.Collections.Generic;
using Common;
using Components;
using Level;
using UnityEngine;
using UnityEngine.Assertions;

namespace Weapons
{
    public sealed class WeaponService : MonoBehaviour
    {
        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private Transform world;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        
        private void FixedUpdate()
        {
            this._cache.Clear();
            this._cache.AddRange(this._activeBullets);

            for (int index = 0, count = this._cache.Count; index < count; index++)
            {
                var bullet = this._cache[index];
                if (this.levelBounds.InBounds(bullet.transform.position) == false)
                {
                    this.bulletFactory.RemoveObject(bullet);
                }
            }
        }

        public void Fire(TeamComponent team, WeaponComponent weapon, Vector2 targetDirection)
        {
            var bulletLayer = team.IsPlayer
                ? PhysicsLayer.PlayerBullet
                : PhysicsLayer.EnemyBullet;

            var bullet = this.bulletFactory.CreateObject();
            Assert.IsNotNull(bullet,
                $"Фабрика '{this.bulletFactory.GetType()}' должна выпускать '{bullet.GetType()}'!");

            bullet.SetParent(this.world);
            bullet.SetPosition(weapon.Position);
            bullet.SetColor(weapon.BulletConfig.Color);
            bullet.SetPhysicsLayer(bulletLayer);
            bullet.SetVelocity(weapon.Rotation * targetDirection * weapon.BulletConfig.Speed);
            bullet.Damage = weapon.BulletConfig.Damage;
            bullet.IsPlayer = team.IsPlayer;

            if (this._activeBullets.Add(bullet))
            {
                bullet.OnCollision += this.OnBulletCollision;
                bullet.gameObject.SetActive(true);
            }
            else
            {
                this.bulletFactory.RemoveObject(bullet);
            }
        }

        private void OnBulletCollision(Bullet bullet, HitPointsComponent hitPointsComponent)
        {
            hitPointsComponent.TakeDamage(bullet.Damage);
            if (this._activeBullets.Remove(bullet))
            {
                this.bulletFactory.RemoveObject(bullet);
            }
        }
    }
}