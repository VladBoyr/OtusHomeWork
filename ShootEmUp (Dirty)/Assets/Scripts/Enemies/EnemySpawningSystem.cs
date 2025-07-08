using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace Enemies
{
    public sealed class EnemySpawningSystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private float spawnInterval = 1.0f;
        [SerializeField] private Transform world;

        private PlayerUnit _playerUnit;
        private readonly HashSet<EnemyUnit> _activeEnemies = new();

        public void Initialize(PlayerUnit playerUnit)
        {
            this._playerUnit = playerUnit;
        }

        // ReSharper disable once IteratorNeverReturns
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(this.spawnInterval);

                var enemy = this.enemyFactory.CreateObject();
                Assert.IsNotNull(enemy,
                    $"Фабрика '{this.enemyFactory.GetType()}' должна выпускать '{enemy.GetType()}'!");

                if (this._activeEnemies.Add(enemy) == false) continue;

                enemy.Initialize(
                    this.world,
                    this.enemyPositions.RandomSpawnPosition().position,
                    this.enemyPositions.RandomAttackPosition().position,
                    this._playerUnit.transform,
                    );
            }
        }

        private void OnEnemyDestroyed(GameObject enemyObject)
        {
            if (enemyObject.TryGetComponent<EnemyUnit>(out var enemy) == false) return;

            if (this._activeEnemies.Remove(enemy) == false) return;

            enemy.Health.OnDeath -= OnEnemyDestroyed;
            enemy.AttackAgent.OnFire -= OnEnemyFire;
            this.enemyFactory.RemoveEnemy(enemy);
        }
    }
}