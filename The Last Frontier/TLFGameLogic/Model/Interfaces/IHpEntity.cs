using System;

namespace TLFGameLogic.Model.Interfaces
{
    public interface IHpEntity
    {
        //TODO Have a look at set modifier (maybe private)
        float CurrentHp { get; set; }
        float MaxHp { get; set; }

        void TakeDamage(float damage);
        void Heal(float hpToHeal);

        event EventHandler LethalDamage;
    }
}