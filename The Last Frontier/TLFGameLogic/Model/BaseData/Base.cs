using System;
using TLFGameLogic.Model.Interfaces;

namespace TLFGameLogic.Model.BaseData
{
    public class Base : IHpEntity
    {
        public float CurrentHp { get; set; }
        public float MaxHp { get; set; }

        public event EventHandler LethalDamage = delegate { };

        public Base()
        {
        }

        public Base(float maxHp)
        {
            CurrentHp = maxHp;
            MaxHp = maxHp;
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
    }
}