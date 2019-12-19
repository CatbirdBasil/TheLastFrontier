using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Model
{
    public class LevelInfo
    {
        private readonly List<Enemy> _aliveEnemies;
        private readonly List<EnemySpawnInfo> _enemiesSpawnInfo;

        public LevelInfo()
        {
            LevelFinishTime = 60f;
            BigWaveStartTimes = new List<float>();
            EstimatedMaxEnemiesOnScreen = new Dictionary<EnemyType, int>();
            _enemiesSpawnInfo = new List<EnemySpawnInfo>();
            EnemiesSpawnInfo = new ReadOnlyCollection<EnemySpawnInfo>(_enemiesSpawnInfo);
            _aliveEnemies = new List<Enemy>();
        }

        public float LevelFinishTime { get; internal set; }
        public Dictionary<EnemyType, int> EstimatedMaxEnemiesOnScreen { get; internal set; }
        public List<float> BigWaveStartTimes { get; internal set; }
        public int Reward { get; internal set; }
        public int LevelNumber { get; internal set; }

        public ReadOnlyCollection<EnemySpawnInfo> EnemiesSpawnInfo { get; }

        public event EventHandler AllEnemiesDead = delegate { };

        internal void AddEnemySpawnInfo(float spawnTime, SpawnPoint spawnPoint, Enemy enemy)
        {
            enemy.LethalDamage += OnEnemyDeath;
            var enemiesSpawnInfo = new EnemySpawnInfo(spawnTime, spawnPoint, enemy);
            _enemiesSpawnInfo.Add(enemiesSpawnInfo);
            _aliveEnemies.Add(enemy);
        }

        private void OnEnemyDeath(object sender, EventArgs eventArgs)
        {
            if (sender is Enemy) _aliveEnemies.Remove(sender as Enemy);

            if (_aliveEnemies.Count == 0) AllEnemiesDead(this, EventArgs.Empty);
        }
    }
}