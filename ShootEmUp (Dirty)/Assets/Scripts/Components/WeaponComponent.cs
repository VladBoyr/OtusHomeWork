using UnityEngine;
using Weapons;

namespace Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [field: SerializeField] public BulletConfig BulletConfig { get; private set; }

        public Vector2 Position => this.firePoint.position;
        public Quaternion Rotation => this.firePoint.rotation;
    }
}