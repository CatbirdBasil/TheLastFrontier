using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public class EnemyView : MonoBehaviour
    {
        public Enemy Enemy { get; set; }

        public GameObject EnemyGameObject { get; set; }
//
//        public EnemyView(Enemy enemy, GameObject gameObject)
//        {
//            _enemy = enemy;
//            EnemyObject = gameObject;
//        }

        public void Move(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Enemy.Speed);
        }

        public void TakeDamage(float damage)
        {
            Enemy.TakeDamage(damage);
        }

        public void Attack()
        {
        }
    }
}