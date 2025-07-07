using System;
using UnityEngine;
using Version2.Components;

namespace Version2.Enemies.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<WeaponComponent> OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown = 1.0f;

        private Transform _target;
        private float _currentTime;

        public void SetTarget(Transform target)
        {
            this._target = target;
        }

        private void OnEnable()
        {
            this._currentTime = countdown;
        }

        private void FixedUpdate()
        {
            if (this.moveAgent.IsReached == false || this._target == null)
            {
                return;
            }

            if (this._target.GetComponent<HitPointsComponent>().IsAlive() == false)
            {
                return;
            }

            this._currentTime -= Time.fixedDeltaTime;

            if (!(this._currentTime <= 0)) return;
            
            this.Fire();
            this._currentTime += countdown;
        }

        private void Fire()
        {
            this.OnFire?.Invoke(weaponComponent);
        }
    }
}