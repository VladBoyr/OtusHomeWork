using UnityEngine;

namespace Enemies
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private Transform[] attackPositions;

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(this.spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(this.attackPositions);
        }

        private static Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}