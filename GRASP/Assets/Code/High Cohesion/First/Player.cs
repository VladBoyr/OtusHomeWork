using UnityEngine;

namespace GRASP
{
    public sealed class Player : MonoBehaviour
    {
        public string Name;
        
        private float _health;
        private float _damage;
        private Vector2 _position;
        
        public void Move(Vector2 direction)
        {
            _position += direction;
        }
        
        public void TakeDamage(float damage)
        {
            _health -= damage;
        }
        
        public void Attack(Player target)
        {
            target.TakeDamage(_damage);
        }
        
        public void Heal(float amount)
        {
            _health += amount;
        }
    }
}
