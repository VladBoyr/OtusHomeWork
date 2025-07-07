using UnityEngine;
using Version2.Components;

namespace Version2.Player
{
    public sealed class PlayerFacade : MonoBehaviour
    {
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        public WeaponComponent Weapon => this.weaponComponent;
        public HitPointsComponent Health => this.hitPointsComponent;
        public Transform Transform => this.transform;

        public void Move(Vector2 direction)
        {
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}