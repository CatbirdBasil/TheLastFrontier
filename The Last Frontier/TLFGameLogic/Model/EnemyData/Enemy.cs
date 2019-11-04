using System;

namespace TLFGameLogic.Model
{
    public class Enemy
    {
        private static ulong LastEnemyId = 0;
        public ulong Id { get; }
        public string Name { get; private set; }

        public float Health { get; private set; }
        public float Damage { get; private set; }
        public float AttackSpeed { get; private set; }
        public float Speed { get; private set; }

        public EnemyType EnemyType { get; internal set; }

        public event EventHandler LethalDamage = delegate { };

        protected Enemy()
        {
            Id = LastEnemyId + 1;
            LastEnemyId = Id;
        }

        internal Enemy(string name, float health, float damage, float attackSpeed, float speed, EnemyType enemyType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Speed = speed;
            Id = LastEnemyId + 1;
            LastEnemyId = Id;
            EnemyType = enemyType;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                LethalDamage(this, EventArgs.Empty);
            }
        }
    }
}