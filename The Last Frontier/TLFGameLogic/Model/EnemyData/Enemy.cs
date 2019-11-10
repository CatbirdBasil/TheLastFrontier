using System;
using TLFGameLogic.Model.Interfaces;

namespace TLFGameLogic.Model
{
    public class Enemy : IHpEntity
    {
        private static ulong LastEnemyId = 0;
        public ulong Id { get; }
        public string Name { get; private set; }
        public float CurrentHp { get; set; }
        public float MaxHp { get; set; }
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
            this.CurrentHp = health;
            this.MaxHp = health;
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
            this.Speed = speed;
            Id = LastEnemyId + 1;
            LastEnemyId = Id;
            EnemyType = enemyType;
        }

        public void TakeDamage(float damage)
        {
            CurrentHp -= damage;

            if (CurrentHp <= 0)
            {
                LethalDamage(this, EventArgs.Empty);
            }
        }

        public void Heal(float hpToHeal)
        {
            if (CurrentHp > 0)
            {
                CurrentHp += hpToHeal;

                if (CurrentHp > MaxHp)
                {
                    CurrentHp = MaxHp;
                }
            }
        }

        public void Attack(IHpEntity target)
        {
            target.TakeDamage(Damage);
        }
    }
}