using Level.EnemySpawning;
using TLFGameLogic.Model;
using TLFGameLogic.Model.LevelData;
using UnityEngine;
using Zenject;

namespace TLFUILogic
{
    public class SimpleEnemyFactory : ScriptableObject, IEnemyFactory
    {
        [Inject] private EnemyPrefabDictionary _enemyPrefabDictionary;
        [Inject] private SpawnPointResolver _spawnPointResolver;

        public EnemyView GetEnemy(Enemy enemy, SpawnPoint spawnPoint)
        {
            var prefab = _enemyPrefabDictionary.GetEnemyPrefab(enemy.EnemyType);

            var spawnPointTransform = _spawnPointResolver.GetSpawnPointTransform(spawnPoint);
            var enemyModel = Instantiate(_enemyPrefabDictionary.GetEnemyPrefab(EnemyType.SmallSlime),
                spawnPointTransform.position, spawnPointTransform.rotation);
            var enemyView = enemyModel.AddComponent<EnemyView>();

            enemyView.EnemyGameObject = enemyModel;
            enemyView.Enemy = enemy;
            enemyView.Rigidbody = enemyModel.GetComponent<Rigidbody2D>();

//            enemyView.Rigidbody.AddForce(-spawnPointTransform.right * enemy.Speed * 10f, ForceMode2D.Force);
            return enemyView;
        }
    }
}