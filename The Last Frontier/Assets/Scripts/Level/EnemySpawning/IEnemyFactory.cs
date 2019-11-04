using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public interface IEnemyFactory
    {
        EnemyView GetEnemy(Enemy enemy, Transform spawnPoint);
    }
}