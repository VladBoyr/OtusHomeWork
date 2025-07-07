using UnityEngine;
using Version2.Components;
using Version2.Enemies.Agents;

namespace Version2.Enemies
{
    public sealed class EnemyFacade : MonoBehaviour
    {
        [field:SerializeField] public EnemyMoveAgent MoveAgent { get; private set; }
        [field:SerializeField] public EnemyAttackAgent AttackAgent { get; private set; }
        [field:SerializeField] public HitPointsComponent Health { get; private set; }
    }
}