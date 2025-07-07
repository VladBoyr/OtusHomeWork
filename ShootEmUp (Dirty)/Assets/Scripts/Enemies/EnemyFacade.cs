using Components;
using Enemies.Agents;
using UnityEngine;

namespace Enemies
{
    public sealed class EnemyFacade : MonoBehaviour
    {
        [field:SerializeField] public EnemyMoveAgent MoveAgent { get; private set; }
        [field:SerializeField] public EnemyAttackAgent AttackAgent { get; private set; }
        [field:SerializeField] public HitPointsComponent Health { get; private set; }
    }
}