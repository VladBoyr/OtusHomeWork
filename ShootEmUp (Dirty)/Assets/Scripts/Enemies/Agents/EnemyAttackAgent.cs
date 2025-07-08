using System;
using Components;
using UnityEngine;

namespace Enemies.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<Vector2> OnFire;

        [SerializeField] private WeaponComponent weapon;
        [SerializeField] private float countdown = 1.0f;

        private Transform _target;
        private bool _canFire;
        private bool _readyToFire;
        private float _currentTime;
        
        public void SetTarget(Transform target)
        {
            this._target = target;
        }

        public void SetReadyToFire(bool readyToFire)
        {
            this._readyToFire = readyToFire;
        }

        private void OnEnable()
        {
            this._currentTime = countdown;
            this._canFire = true;
        }

        private void OnDisable()
        {
            this._canFire = false;
        }

        private void FixedUpdate()
        {
            if (this._canFire == false || this._readyToFire == false || this._target == null)
            {
                return;
            }

            this._currentTime -= Time.fixedDeltaTime;
            if (this._currentTime > 0) return;
            this._currentTime += countdown;
            
            this.Fire();
        }

        private void Fire()
        {
            var targetDirection = (Vector2)this._target.transform.position - this.weapon.Position;
            targetDirection = targetDirection.normalized;
            this.OnFire?.Invoke(targetDirection);
        }
    }
}