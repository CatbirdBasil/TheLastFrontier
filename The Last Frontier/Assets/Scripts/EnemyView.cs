using TLFGameLogic.Model;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace TLFUILogic
{
    public class EnemyView : MonoBehaviour
    {
        protected Enemy _enemy;
        public GameObject EnemyObject { get; }

        public EnemyView(Enemy enemy, GameObject gameObject)
        {
            _enemy = enemy;
            EnemyObject = gameObject;
        }

        public void Move(UnityEngine.Vector2 target)
        {
            this.transform.position = UnityEngine.Vector2.MoveTowards(this.transform.position, target, _enemy.Speed);
        }

        public void TakeDamage(float damage)
        {
            _enemy.TakeDamage(damage);
        }

        public void Attack()
        {
        }
    }
}