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
            var bigWaveStartTimes = new List<float>(1);
            bigWaveStartTimes.Add(30f);
            levelInfo.BigWaveStartTimes = bigWaveStartTimes;

            levelInfo.AddEnemySpawnInfo(3f, SpawnPoint.A, new SmallSlimeEnemy());
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