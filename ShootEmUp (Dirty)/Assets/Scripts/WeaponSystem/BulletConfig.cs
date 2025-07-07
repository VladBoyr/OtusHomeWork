using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Bullet Version 2/New BulletConfig")]
    public sealed class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; } = Color.white;
        [field: SerializeField] public int Damage { get; private set; } = 1;
        [field: SerializeField] public float Speed { get; private set; } = 3.0f;
    }
}