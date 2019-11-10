using ModestTree;
using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public class EnemyViewModel : MonoBehaviour
    {
        public Enemy Enemy { get; set; }

        public Rigidbody2D RigidBody { get; set; }

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