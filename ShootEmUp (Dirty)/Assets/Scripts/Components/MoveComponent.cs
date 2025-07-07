using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 5.0f;
        
        public void MoveByRigidbodyVelocity(Vector2 direction)
        {
            var nextPosition = this.rigidbody2D.position + direction * this.speed;
            this.rigidbody2D.MovePosition(nextPosition);
        }

        private void OnValidate()
        {
            if (this.rigidbody2D == null)
            {
                this.rigidbody2D = GetComponent<Rigidbody2D>();
            }
        }
    }
}