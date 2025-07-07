using System.Collections.Generic;
using UnityEngine;
using Version2.Player;

namespace Version2.Enemies
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyFacade enemyPrefab;
        [SerializeField] private Transform container;
        [SerializeField] private int initialCount = 10;

        [Header("Dependencies")] [SerializeField]
        private EnemyPositions enemyPositions;

        private readonly Queue<EnemyFacade> _enemyPool = new();
        private PlayerFacade _playerFacade;

        public void Initialize(PlayerFacade playerFacade)
        {
            this._playerFacade = playerFacade;
            for (var i = 0; i < initialCount; i++)
            {
                var enemy = Instantiate(this.enemyPrefab, this.container);
                this._enemyPool.Enqueue(enemy);
            }
        }

        public EnemyFacade SpawnEnemy()
        {
            if (this._enemyPool.TryDequeue(out var enemy) == false)
            {
                enemy = Instantiate(this.enemyPrefab);
            }

            enemy.transform.SetParent(null);

            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = this.enemyPositions.RandomAttackPosition();
            enemy.MoveAgent.SetDestination(attackPosition.position);
            enemy.AttackAgent.SetTarget(this._playerFacade.Transform);

            return enemy;
        }

        public void UnspawnEnemy(EnemyFacade enemy)
        {
            enemy.transform.SetParent(this.container);
            enemy.gameObject.SetActive(false);
            this._enemyPool.Enqueue(enemy);
        }
    }
}