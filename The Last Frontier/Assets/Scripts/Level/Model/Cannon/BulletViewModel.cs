using System;
using TLFUILogic;
using UnityEngine;

namespace Level.Model.Cannon
{
    public class BulletViewModel : MonoBehaviour
    {
        public float Damage { get; set; }
        public float Speed { get; set; }

        public GameObject BulletGameObject { get; set; }
        public Rigidbody2D RigidBody { get; set; }

        public event EventHandler OnCollision = delegate { };

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            if (hitInfo.gameObject.CompareTag("Background")) // TODO Make constant and move to constants class
                OnCollision(this, EventArgs.Empty);

            var enemyViewModel = hitInfo.gameObject.GetComponent<EnemyViewModel>();

            if (enemyViewModel != null)
            {
                enemyViewModel.TakeDamage(Damage);
                OnCollision(this, EventArgs.Empty);
            }
        }
    }
}