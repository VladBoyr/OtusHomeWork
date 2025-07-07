using Components;
using UnityEngine;

namespace Enemies.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached { get; private set; }

        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private float stoppingDistance = 0.1f;
        
        private Vector2 _destination;

        public void SetDestination(Vector2 endPoint)
        {
            this._destination = endPoint;
            this.IsReached = false;
        }

        private void FixedUpdate()
        {
            if (this.IsReached)
            {
                this.moveComponent.MoveByRigidbodyVelocity(Vector2.zero);
                return;
            }
            
            var vectorToDestination = this._destination - (Vector2)this.transform.position;
            
            if (vectorToDestination.magnitude <= this.stoppingDistance)
            {
                this.IsReached = true;
                return;
            }

            var direction = vectorToDestination.normalized * Time.fixedDeltaTime;
            
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }

        private void OnDisable()
        {
            this.IsReached = true; 
        }
    }
}