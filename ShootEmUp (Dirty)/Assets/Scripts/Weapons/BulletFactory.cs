using Core;
using UnityEngine;

namespace Weapons
{
    public sealed class BulletFactory : ObjectPool<Bullet>
    {
        protected override void OnReturnToPool(Bullet bullet)
        {
            base.OnReturnToPool(bullet);
            bullet.SetVelocity(Vector2.zero);
            bullet.ClearCollisionHandlers();
        }
    }
}