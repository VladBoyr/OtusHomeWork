using System;
using UnityEngine;

namespace Enemies.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action<Vector2> OnMove;
        public event Action OnDestinationReached;

        [SerializeField] private float stoppingDistance = 0.1f;
        
        private Vector2 _destination;
        private bool _destinationReached;
        private bool _canMove;

        public void SetDestination(Vector2 endPoint)
        {
            this._destination = endPoint;
            this._destinationReached = false;
        }

        private void OnEnable()
        {
            this._canMove = true;
        }

        private void OnDisable()
        {
            this._canMove = false;
        }

        private void FixedUpdate()
        {
            if (this._canMove == false || this._destinationReached)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            var vectorToDestination = this._destination - (Vector2)this.transform.position;
            if (vectorToDestination.magnitude <= this.stoppingDistance)
            {
                this._destinationReached = true;
                this.OnDestinationReached?.Invoke();
                return;
            }

            var direction = vectorToDestination.normalized * Time.fixedDeltaTime;
            this.OnMove?.Invoke(direction);
        }
    }
}