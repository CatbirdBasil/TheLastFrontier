using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace TLFUILogic
{
    public class SimpleEnemyFactory : ScriptableObject, IEnemyFactory
    {
        [Inject] private EnemyPrefabDictionary _enemyPrefabDictionary;

        public EnemyView GetEnemy(Enemy enemy, Transform spawnPoint)
        {
            var prefab = _enemyPrefabDictionary.GetEnemyPrefab(enemy.EnemyType);
            Debug.Log("Prefab(" + prefab.name + ")");
//            Debug.Log("Dic(" + _enemyPrefabDictionary == null + ")");
            var rb = prefab.GetComponent<Rigidbody2D>();
            //if it will be necessary add switch 
            var enemyModel = Instantiate(_enemyPrefabDictionary.GetEnemyPrefab(EnemyType.SmallSlime),
                spawnPoint.position, spawnPoint.rotation);
            //TODO
            var enemyView = enemyModel.AddComponent<EnemyView>();
            enemyView.EnemyGameObject = enemyModel;
            enemyView.Enemy = enemy;
            return enemyView;
        }
    }
}