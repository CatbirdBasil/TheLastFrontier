using System;

namespace TLFGameLogic.Model
{
    public abstract class Enemy
    {
        private static ulong LastEnemyId = 0;
        public ulong Id { get; }
        public string Name { get; protected set; }
        
        public float Health { get; protected set; }
        public float Damage { get; protected set; }
        public float AttackSpeed { get; protected set; }
        public float Speed { get; protected set; }

        public event EventHandler LethalDamage = delegate { };

        protected Enemy()
        {
            Id = LastEnemyId + 1;
            LastEnemyId = Id;
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