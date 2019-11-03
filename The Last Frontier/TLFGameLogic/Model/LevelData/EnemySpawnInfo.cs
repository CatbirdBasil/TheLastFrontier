using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Model
{
    public class EnemySpawnInfo
    {
        public float SpawnTime { get; }
        public SpawnPoint SpawnPoint { get; }
        public Enemy Enemy { get; }

        public EnemySpawnInfo(float spawnTime, SpawnPoint spawnPoint, Enemy enemy)
        {
            SpawnTime = spawnTime;
            SpawnPoint = spawnPoint;
            Enemy = enemy;
        }
    }
}