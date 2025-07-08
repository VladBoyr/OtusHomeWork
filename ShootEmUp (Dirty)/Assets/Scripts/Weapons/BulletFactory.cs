using Core;
using UnityEngine;

namespace Weapons
{
    public sealed class BulletFactory : ObjectPool<Bullet>
    {
        public override void RemoveObject(Bullet bullet)
        {
            bullet.SetVelocity(Vector2.zero);
            base.RemoveObject(bullet);
        }
    }
}