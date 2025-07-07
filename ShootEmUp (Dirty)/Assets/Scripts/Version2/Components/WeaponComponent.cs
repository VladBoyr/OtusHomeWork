using UnityEngine;

namespace Version2.Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;

        public Vector2 Position => this.firePoint.position;
        public Quaternion Rotation => this.firePoint.rotation;
    }
}