using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Config
{
    public class Levels
    {
        private static readonly Dictionary<int, LevelInfo> _levelInfos = new Dictionary<int, LevelInfo>
        {
            {1, Level1()},
            {2, Level2()},
            {3, Level3()}
        };

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

            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(6f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(6f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(9f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(9f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(9f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.Reward = 100;
            levelInfo.LevelNumber = 1;

            return levelInfo;
        }

        private static LevelInfo Level2()
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

            levelInfo.Reward = 250;
            levelInfo.LevelNumber = 2;

            return levelInfo;
        }

        private static LevelInfo Level3()
        {
            var levelInfo = new LevelInfo();
            levelInfo.BigWaveStartTimes = new List<float>
            {
                30f
            };

            levelInfo.EstimatedMaxEnemiesOnScreen = new Dictionary<EnemyType, int>
            {
                {EnemyType.SmallSlime, 50}
            };


            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));


            levelInfo.AddEnemySpawnInfo(5f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(7f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(9f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));


            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(11f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));


            levelInfo.AddEnemySpawnInfo(20f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(18f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(17f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(16f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(15f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(14f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(19f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(21f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(21f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(22f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(23f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(24f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(25f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(26f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));


            levelInfo.AddEnemySpawnInfo(37f, SpawnPoint.A, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(36f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(35f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(34f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(33f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(32f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(31f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(29f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(33f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(35f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(37f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(39f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(41f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));

            levelInfo.AddEnemySpawnInfo(38f, SpawnPoint.B, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(39f, SpawnPoint.C, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(40f, SpawnPoint.D, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(41f, SpawnPoint.E, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(42f, SpawnPoint.F, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(43f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));
            levelInfo.AddEnemySpawnInfo(45f, SpawnPoint.G, EnemyFactory.CreateEnemy(EnemyType.SmallSlime));


            levelInfo.Reward = 1000;
            levelInfo.LevelNumber = 3;

            return levelInfo;
        }

        public static LevelInfo Get(int level)
        {
            return _levelInfos[level];
        }

        public static int GetLevelAmount()
        {
            return _levelInfos.Count;
        }
    }
}