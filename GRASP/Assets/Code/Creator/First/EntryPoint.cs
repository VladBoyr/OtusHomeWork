using UnityEngine;

namespace GRASP.First
{
    public enum EnemyType : byte
    {
        None = 0,
        Melee = 1,
        Ranged = 2
    }
    
    public sealed class Enemy
    {
        public readonly EnemyType Type;
    }
    
    public sealed class Spawner
    {
        public Enemy SpawnEnemyInRandomPoint()
        {
            return new Enemy();
        }
    }

    public sealed class SpawnController
    {
        private readonly Enemy _enemy;

        public SpawnController()
        {
            Spawner spawner = new Spawner();
            _enemy = spawner.SpawnEnemyInRandomPoint();
        }
    }

    public sealed class EnemiesController
    {
        private readonly SpawnController _spawnController;

        public EnemiesController()
        {
            _spawnController = new SpawnController();
        }
    }

    public sealed class EntryPoint : MonoBehaviour
    {
        private void Start()
        {
            EnemiesController enemiesController = new EnemiesController();
        }
    }
}
