using TLFGameLogic.Model;

namespace TLFUILogic
{
    public interface IEnemyFactory
    {
         EnemyView getEnemy(Enemy enemy);
    }
}