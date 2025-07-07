using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;
using WeaponSystem;

namespace Enemies
{
    public sealed class EnemySpawningSystem : MonoBehaviour
    {
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private float spawnInterval = 1.0f;
        [SerializeField] private BulletConfig enemyBulletConfig;

        private WeaponService _weaponService;
        private readonly HashSet<EnemyFacade> _activeEnemies = new();

        public void Initialize(WeaponService weaponService)
        {
            this._weaponService = weaponService;
        }

        public void StartSpawning()
        {
            this.StartCoroutine(this.SpawnRoutine());
        }

        // ReSharper disable once IteratorNeverReturns
        private IEnumerator SpawnRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(this.spawnInterval);

                var enemy = this.enemyFactory.SpawnEnemy();
                if (enemy == null) continue;

                enemy.gameObject.SetActive(true);
                
                if (this._activeEnemies.Add(enemy) == false) continue;

                enemy.Health.OnHpEmpty += OnEnemyDestroyed;
                enemy.AttackAgent.OnFire += OnEnemyFire;
            }
        }

        private void OnEnemyDestroyed(GameObject enemyObject)
        {
            if (enemyObject.TryGetComponent<EnemyFacade>(out var enemy) == false) return;

            if (this._activeEnemies.Remove(enemy) == false) return;

            enemy.Health.OnHpEmpty -= OnEnemyDestroyed;
            enemy.AttackAgent.OnFire -= OnEnemyFire;
            this.enemyFactory.UnspawnEnemy(enemy);
        }

        private void OnEnemyFire(WeaponComponent weapon, Vector2 targetDirection)
        {
            this._weaponService.Fire(weapon, this.enemyBulletConfig, targetDirection);
        }
    }
}