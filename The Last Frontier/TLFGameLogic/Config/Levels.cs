using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Config
{
    public class Levels
    {
        private static LevelInfo Level1()
        {
            var levelInfo = new LevelInfo();
            levelInfo.BigWaveStartTimes = new List<float>
            {
                30f
            };

            levelInfo.EstimatedMaxEnemiesOnScreen = new Dictionary<EnemyType, int>
            {
                {EnemyType.SmallSlime, 14}
            };
            
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(6f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(1f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            return levelInfo;
        }

        public static LevelInfo Get(int level)
        {
            switch (level)
            {
                case 1: return Level1();
                default: return null;
            }
        }
    }
}