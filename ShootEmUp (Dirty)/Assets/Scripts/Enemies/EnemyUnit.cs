using Components;
using Core;
using Enemies.Agents;
using UnityEngine;

namespace Enemies
{
    public sealed class EnemyUnit : Unit
    {
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private EnemyAttackAgent attackAgent;
        [SerializeField] private HitPointsComponent health;

        public void Initialize(
            Transform parent,
            Vector3 initialPosition,
            Vector2 attackPosition,
            Transform target,
            EnemyAttackAgent.FireHandler fireHandler,
             healthHandler)
        {
            this.transform.SetParent(parent);
            this.transform.position = initialPosition;
            this.moveAgent.SetDestination(attackPosition);
            this.attackAgent.SetTarget(target);
            this.attackAgent.OnFire += fireHandler;
            this.health.OnDeath += OnEnemyDestroyed;
            // private IWeaponService _weaponService;
            // this._weaponService = weaponService;
            this.gameObject.SetActive(true);
        }
    }
}