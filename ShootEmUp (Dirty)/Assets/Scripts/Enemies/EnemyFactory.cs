using Core;
using UnityEngine;
using Weapons;

namespace Enemies
{
    public sealed class EnemyFactory : ObjectPool<EnemyUnit>
    {
        [SerializeField] private WeaponService weaponService;

        protected override void InitializeObject(EnemyUnit obj)
        {
            base.InitializeObject(obj);
            obj.Initialize(weaponService);
        }
    }
}