using Core;
using Enemies.Agents;
using UnityEngine;
using Weapons;

namespace Enemies
{
    public sealed class EnemyUnit : Unit
    {
        [SerializeField] private EnemyAttackAgent enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent enemyMoveAgent;

        private WeaponService _weaponService;

        public void Initialize(WeaponService weaponService)
        {
            this._weaponService = weaponService;
        }

        public void OnEnable()
        {
            this.enemyAttackAgent.OnFire += this.Fire;
            this.enemyMoveAgent.OnMove += this.Move;
            this.enemyMoveAgent.OnDestinationReached += AttackPositionReached;
        }
        
        public void OnDisable()
        {
            this.enemyAttackAgent.OnFire -= this.Fire;
            this.enemyMoveAgent.OnMove -= this.Move;
            this.enemyMoveAgent.OnDestinationReached -= AttackPositionReached;
        }
        
        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetDestination(Vector3 destination)
        {
            this.enemyMoveAgent.SetDestination(destination);
        }

        public void SetTarget(Transform target)
        {
            this.enemyAttackAgent.SetTarget(target);
        }

        private void Fire(Vector2 targetDirection)
        {
            this._weaponService.Fire(this.TeamComponent, this.WeaponComponent, targetDirection);
        }
        
        private void Move(Vector2 moveDirection)
        {
            if (moveDirection == Vector2.zero) return;
            this.MoveComponent.MoveByRigidbodyVelocity(moveDirection * Time.fixedDeltaTime);
        }
        
        private void AttackPositionReached()
        {
            this.enemyAttackAgent.SetReadyToFire(true);
        }
    }
}