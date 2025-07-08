using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Assertions;
using Weapons;

namespace Enemies
{
    public sealed class EnemySpawningSystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private float spawnInterval = 1.0f;
        [SerializeField] private Transform world;
        [SerializeField] private PlayerUnit playerUnit;
        [SerializeField] private WeaponService weaponService;

        private readonly HashSet<EnemyUnit> _activeEnemies = new();
        private readonly Dictionary<EnemyUnit, Action<GameObject>> _deathHandlers = new();

        private Coroutine _spawningCoroutine;

        private void OnEnable() {
            _spawningCoroutine = StartCoroutine(SpawningProcess());
        }

        private void OnDisable() {
            if (_spawningCoroutine != null) {
                StopCoroutine(_spawningCoroutine);
            }
        }

        // ReSharper disable once IteratorNeverReturns
        private IEnumerator SpawningProcess()
        {
            while (true)
            {
                yield return new WaitForSeconds(this.spawnInterval);

                var enemy = this.enemyFactory.CreateObject();
                Assert.IsNotNull(enemy,
                    $"Фабрика '{this.enemyFactory.GetType()}' должна выпускать '{enemy.GetType()}'!");

                enemy.Initialize(this.weaponService);
                enemy.SetParent(this.world);
                enemy.SetPosition(this.enemyPositions.RandomSpawnPosition().position);
                enemy.SetDestination(this.enemyPositions.RandomAttackPosition().position);
                enemy.SetTarget(this.playerUnit.transform);

                if (this._activeEnemies.Add(enemy))
                {
                    Action<GameObject> handler = gameObj => OnEnemyDestroyed(gameObj, enemy);
                    _deathHandlers.Add(enemy, handler);
                    enemy.HitPointsComponent.OnDeath += handler;
                    enemy.gameObject.SetActive(true);
                }
                else
                {
                    this.enemyFactory.RemoveObject(enemy);
                }
            }
        }

        private void OnEnemyDestroyed(GameObject _, EnemyUnit enemy)
        {
            if (this._activeEnemies.Remove(enemy) == false) return;

            if (this._deathHandlers.TryGetValue(enemy, out var handler))
            {
                enemy.HitPointsComponent.OnDeath -= handler;
                this._deathHandlers.Remove(enemy);
            }

            this.enemyFactory.RemoveObject(enemy);
        }
    }
}