using UnityEngine;
using Version2.Components;
using Version2.WeaponSystem;

namespace Version2.HealthSystem
{
    public sealed class DamageHandler
    {
        public static void HandleDamage(Bullet bullet, GameObject other)
        {
            if (other.TryGetComponent<TeamComponent>(out var teamComponent) == false)
            {
                return;
            }

            if (bullet.IsPlayer == teamComponent.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent<HitPointsComponent>(out var hitPointsComponent))
            {
                hitPointsComponent.TakeDamage(bullet.Damage);
            }
        }
    }
}