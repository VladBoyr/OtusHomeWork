using System;
using UnityEngine;

namespace Components
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnDeath;
        
        [SerializeField] private int hitPoints;

        public bool IsDied() => this.hitPoints <= 0;

        public void TakeDamage(int damage)
        {
            if (this.IsDied()) return;
            
            this.hitPoints -= damage;
            if (this.IsDied())
            {
                this.OnDeath?.Invoke(this.gameObject);
            }
        }
    }
}