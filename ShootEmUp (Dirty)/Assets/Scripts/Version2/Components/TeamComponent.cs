using UnityEngine;

namespace Version2.Components
{
    public sealed class TeamComponent : MonoBehaviour
    {
        [field: SerializeField] 
        public bool IsPlayer { get; private set; }
    }
}