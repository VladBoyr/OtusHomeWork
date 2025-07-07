using System;
using UnityEngine;

namespace Version2.Components
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnHpEmpty;
        
        [SerializeField] private int hitPoints;

        public bool IsAlive() => this.hitPoints > 0;

        public void TakeDamage(int damage)
        {
            if (this.IsAlive() == false) return;
            
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                this.OnHpEmpty?.Invoke(this.gameObject);
            }
        }
    }
}