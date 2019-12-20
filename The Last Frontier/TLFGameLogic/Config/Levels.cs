using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Config
{
    public class Levels
    {
        private static int _levelAmount = 1;
        private static LevelInfo Level1()
        {
            var levelInfo = new LevelInfo();
            levelInfo.BigWaveStartTimes = new List<float>
            {
                15f
            };

            levelInfo.EstimatedMaxEnemiesOnScreen = new Dictionary<EnemyType, int>
            {
                {EnemyType.SmallSlime, 14}
            };


            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(6f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(1f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(4f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(5f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.Reward = 100;
            levelInfo.LevelNumber = 1;

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

        public static int GetLevelAmount()
        {
            return _levelAmount;
        }
    }
}