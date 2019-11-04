using TLFGameLogic.Model;
using UnityEngine;
using Zenject;
using Vector2 = System.Numerics.Vector2;

namespace TLFUILogic
{
    public class SimpleEnemyFactory : MonoBehaviour
    {
        public  EnemyView getEnemy(Enemy enemy,Transform spawnPoint)
        {
            DictionaryEnemy dictionaryEnemy =new DictionaryEnemy();
            GameObject prefab = dictionaryEnemy.getEnemyPrefab(enemy.EnemyType);
            Rigidbody2D rb = prefab.GetComponent<Rigidbody2D>();
            //if it will be necessary add switch 
            GameObject enemyModel = Instantiate(dictionaryEnemy.getEnemyPrefab(EnemyType.SmallSlime),spawnPoint.position,spawnPoint.rotation );
            return new EnemyView(enemy,enemyModel);
        }
    }
}