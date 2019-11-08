using System;
using System.Collections.Generic;
using Level.EnemySpawning;
using Level.LevelEventArgs;
using TLFGameLogic.Model;
using TLFUILogic;
using UnityEngine;
using Zenject;

namespace Level
{
    public class SpawnManager : MonoBehaviour
    {
        private float _currentAbsoluteTime;

        private List<EnemySpawnInfo> _enemiesSpawnInfo;
        [Inject] private IEnemyFactory _enemyFactory;
        private bool _isLoading;
        [Inject] private LevelLoader _levelLoader;
        [Inject] private SpawnPointResolver _spawnPointResolver;

        private void Update()
        {
            if (!_isLoading)
            {
                _currentAbsoluteTime += Time.deltaTime;
                TrySpawnEnemies();
            }
        }

        private void OnEnable()
        {
            _currentAbsoluteTime = 0;
            _isLoading = true;

            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            _levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        private void OnDisable()
        {
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            _levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {
            var enemiesSpawnInfo = new List<EnemySpawnInfo>(args.LevelInfo.EnemiesSpawnInfo);
            enemiesSpawnInfo.Sort((x, y) => y.SpawnTime.CompareTo(x.SpawnTime));
            _enemiesSpawnInfo = enemiesSpawnInfo;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
            _isLoading = false;
        }

        private void TrySpawnEnemies()
        {
            for (var i = _enemiesSpawnInfo.Count - 1; i >= 0; i--)
            {
                var enemySpawnInfo = _enemiesSpawnInfo[i];

                if (enemySpawnInfo.SpawnTime <= _currentAbsoluteTime)
                {
                    var enemyViewModel = _enemyFactory.GetEnemy(enemySpawnInfo.Enemy);

                    var spawnPointTransform = _spawnPointResolver.GetSpawnPointTransform(enemySpawnInfo.SpawnPoint);
                    enemyViewModel.EnemyGameObject.transform.position = spawnPointTransform.position;
                    enemyViewModel.EnemyGameObject.transform.rotation = spawnPointTransform.rotation;

//                    enemyViewModel.Rigidbody.AddForce(enemyViewModel.Enemy.Speed * 50f * (-spawnPointTransform.right), ForceMode2D.Force);

                    _enemiesSpawnInfo.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }
    }
}