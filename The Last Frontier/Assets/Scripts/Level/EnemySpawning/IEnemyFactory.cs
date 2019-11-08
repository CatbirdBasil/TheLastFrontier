using System.Collections.Generic;
using TLFGameLogic.Model;

namespace TLFUILogic
{
    public interface IEnemyFactory
    {
        void WarmUp(Dictionary<EnemyType, int> estimatedEnemiesOnScreen);

        EnemyViewModel GetEnemy(Enemy enemy);
    }
}