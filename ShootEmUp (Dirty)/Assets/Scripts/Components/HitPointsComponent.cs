using System;
using UnityEngine;

namespace Components
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDeath;
        
        [SerializeField] private int initialHitPoints;

        private int _currentHitPoints;

        private void Awake()
        {
            _currentHitPoints = initialHitPoints;
        }

        public void Reset()
        {
            _currentHitPoints = initialHitPoints;
        }

        private bool IsDied() => this._currentHitPoints <= 0;

        public void TakeDamage(int damage)
        {
            if (this.IsDied()) return;
            
            this._currentHitPoints -= damage;
            if (this.IsDied())
            {
                this.OnDeath?.Invoke(this.gameObject);
            }
        }
    }
}