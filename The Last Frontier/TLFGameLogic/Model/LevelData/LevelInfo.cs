using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TLFGameLogic.Model.LevelData;

namespace TLFGameLogic.Model
{
    public class LevelInfo
    {
        public List<float> BigWaveStartTimes { get; internal set; }
        /// <summary>
        ///TODO ADD TIME END
        /// </summary>

        public ReadOnlyCollection<EnemySpawnInfo> EnemiesSpawnInfo { get; }
        private List<EnemySpawnInfo> _enemiesSpawnInfo;

        public event EventHandler AllEnemiesDead = delegate {  };
        
        public LevelInfo()
        {
            BigWaveStartTimes = new List<float>();
            _enemiesSpawnInfo = new List<EnemySpawnInfo>();
            EnemiesSpawnInfo = new ReadOnlyCollection<EnemySpawnInfo>(_enemiesSpawnInfo);
        }
        
        internal void AddEnemySpawnInfo(float spawnTime, SpawnPoint spawnPoint, Enemy enemy)
        {
            enemy.LethalDamage += OnEnemyDeath;
            EnemySpawnInfo enemiesSpawnInfo = new EnemySpawnInfo(spawnTime, spawnPoint, enemy);
            _enemiesSpawnInfo.Add(enemiesSpawnInfo);
        }

        private void OnEnemyDeath(Object sender, EventArgs eventArgs)
        {
            if (sender is Enemy)
            {
                EnemySpawnInfo enemySpawnInfo = _enemiesSpawnInfo.Find((info => info.Enemy.Equals(sender)));
                _enemiesSpawnInfo.Remove(enemySpawnInfo);
            }

            if (EnemiesSpawnInfo.Count == 0)
            {
                AllEnemiesDead(this, EventArgs.Empty);
            }
        }
    }
}