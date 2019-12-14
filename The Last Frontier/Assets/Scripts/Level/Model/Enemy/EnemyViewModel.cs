
using Level;
using Level.Cannon;
using Level.LevelEventArgs;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;


namespace TLFUILogic
{
    public class EnemyViewModel : MonoBehaviour
    {
        [Inject] private BaseEventArgs _base;
        public static int BASE_X_POSITION = -10;
        
        public Enemy Enemy { get; set; }

        public void Update()
        {
         if(transform.position.x>BASE_X_POSITION-3f)
             Move();
         else
             Attack();
         

        }

        public Rigidbody2D RigidBody { get; set; }

        public void Move()
        {
            Vector2 target = new Vector2(BASE_X_POSITION, transform.position.y);
            transform.position  = Vector2.MoveTowards(transform.position, target, (float) (Enemy.Speed*0.01));
           
        }

        public void TakeDamage(float damage)
        {
            Enemy.TakeDamage(damage);
        }

        public void Attack()
        {
            var currentBase = _base.CurrentBase;
            currentBase.TakeDamage(Enemy.Damage);
        }
    }
}