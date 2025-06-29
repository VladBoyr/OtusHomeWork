using UnityEngine;

namespace GRASP
{
    public sealed class EnemyData
    {
        public readonly Vector2 Position;

        public float GetXPosition()
        {
            return Position.x;
        }
    }
    
    public sealed class SpawnerData
    {
        public readonly EnemyData EnemyData;
        

        public float GetXPosition()
        {
            return EnemyData.GetXPosition();
        }
    }
    
    public sealed class Spawner : ISpawner
    {
        public SpawnerData Data { get; }
        public void Spawn() { }
        
        public float GetXPosition()
        {
            return Data.GetXPosition();
        }
    }

    public sealed class Player
    {
        private readonly ISpawner _spawner;

        public Player(ISpawner spawner)
        {
            _spawner = spawner;
        }
        
        public void Spawn()
        {
            float positionY = _spawner.Data.EnemyData.Position.y;  // bad

            float xPosition = _spawner.GetXPosition();  // good
        }
    }

    public interface ISpawner
    {
        SpawnerData Data { get; }
        float GetXPosition();
    }
}
