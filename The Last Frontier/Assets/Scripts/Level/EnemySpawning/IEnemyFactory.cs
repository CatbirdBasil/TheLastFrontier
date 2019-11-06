using TLFGameLogic.Model;
using TLFGameLogic.Model.LevelData;

namespace TLFUILogic
{
    public interface IEnemyFactory
    {
        EnemyView GetEnemy(Enemy enemy, SpawnPoint spawnPoint);
    }
}