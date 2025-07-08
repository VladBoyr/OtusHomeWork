using Core;

namespace Enemies
{
    public sealed class EnemyFactory : ObjectPool<EnemyUnit>
    {
        protected override void OnTakeFromPool(EnemyUnit enemy)
        {
            base.OnTakeFromPool(enemy);
            enemy.ResetState();
        }
    }
}