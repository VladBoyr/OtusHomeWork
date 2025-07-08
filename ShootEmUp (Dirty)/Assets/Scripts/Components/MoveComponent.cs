using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class MoveComponent : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed = 5.0f;
        
        public void SetVelocity(Vector2 direction)
        {
            this._rigidbody2D.velocity = direction * this.speed;
        }

        public void MoveByRigidbodyVelocity(Vector2 direction)
        {
            var nextPosition = this._rigidbody2D.position + direction * this.speed;
            this._rigidbody2D.MovePosition(nextPosition);
        }

        private void OnValidate()
        {
            if (this._rigidbody2D == null)
            {
                this._rigidbody2D = GetComponent<Rigidbody2D>();
            }
        }
    }
}