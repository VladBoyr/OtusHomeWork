using Components;
using UnityEngine;

namespace Core
{
    public class Unit : MonoBehaviour
    {
        [field: SerializeField] public TeamComponent TeamComponent { get; private set; }
        [field: SerializeField] public MoveComponent MoveComponent { get; private set; }
        [field: SerializeField] public WeaponComponent WeaponComponent { get; private set; }
        [field: SerializeField] public HitPointsComponent HitPointsComponent { get; private set; }
    }
}