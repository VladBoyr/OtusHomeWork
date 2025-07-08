using System;
using Common;
using Components;
using UnityEngine;
using UnityEngine.Assertions;

namespace Weapons
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, HitPointsComponent> OnCollision;

        public bool IsPlayer { get; set; }
        public int Damage { get; set; }

        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(PhysicsLayer physicsLayer)
        {
            this.gameObject.layer = (int)physicsLayer;
        }

        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }

        public void ClearCollisionHandlers()
        {
            this.OnCollision = null;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var unit = collision.gameObject;

            if (unit.TryGetComponent<TeamComponent>(out var teamComponent) == false ||
                teamComponent.IsPlayer == this.IsPlayer)
            {
                return;
            }

            var hitPointsComponent = unit.GetComponent<HitPointsComponent>();
            Assert.IsNotNull(hitPointsComponent, $"Объект '{unit.name}' должен иметь компонент '{nameof(HitPointsComponent)}'!");
            this.OnCollision?.Invoke(this, hitPointsComponent);
        }
    }
}