using System.Collections.Generic;
using UnityEngine;
using Version2.HealthSystem;
using Version2.Level;

namespace Version2.WeaponSystem
{
    public sealed class BulletService : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Transform container;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private LevelBounds levelBounds;

        private readonly Queue<Bullet> _bulletPool = new();
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        public void Initialize()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var bullet = Instantiate(this.bulletPrefab, this.container);
                this._bulletPool.Enqueue(bullet);
            }
        }

        private void FixedUpdate()
        {
            this._cache.Clear();
            this._cache.AddRange(this._activeBullets);

            for (int index = 0, count = this._cache.Count; index < count; index++)
            {
                var bullet = this._cache[index];
                if (this.levelBounds.InBounds(bullet.transform.position) == false)
                {
                    this.ReturnBulletToPool(bullet);
                }
            }
        }

        public void FlyBullet(BulletArgs args)
        {
            var bullet = GetBullet();
            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.SetVelocity(args.Velocity);
            bullet.Damage = args.Damage;
            bullet.IsPlayer = args.IsPlayer;

            if (this._activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }

        private Bullet GetBullet()
        {
            if (this._bulletPool.TryDequeue(out var bullet) == false)
            {
                bullet = Instantiate(this.bulletPrefab);
            }

            bullet.transform.SetParent(null);
            return bullet;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            DamageHandler.HandleDamage(bullet, collision.gameObject);
            this.ReturnBulletToPool(bullet);
        }

        private void ReturnBulletToPool(Bullet bullet)
        {
            if (!this._activeBullets.Remove(bullet)) return;

            bullet.OnCollisionEntered -= this.OnBulletCollision;
            bullet.transform.SetParent(this.container);
            bullet.SetVelocity(Vector2.zero);
            this._bulletPool.Enqueue(bullet);
        }

        public struct BulletArgs
        {
            public Vector2 Position;
            public Vector2 Velocity;
            public Color Color;
            public int PhysicsLayer;
            public int Damage;
            public bool IsPlayer;
        }
    }
}