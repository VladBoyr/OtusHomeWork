using UnityEngine;
using Version2.Components;

namespace Version2.Enemies.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public delegate void FireHandler(WeaponComponent weapon, Vector2 targetDirection);

        public event FireHandler OnFire;

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
            var targetDirection = ((Vector2)this._target.transform.position - this.weaponComponent.Position).normalized;
            this.OnFire?.Invoke(weaponComponent, targetDirection);
        }
    }
}