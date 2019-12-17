using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFGameLogic.Model.CannonData.Enum.Barrel;
using TLFUILogic;

namespace TLFGameLogic.Model.CannonData.Barrel
{
    public class Barrel : CannonPart
    {
        public Barrel()
        {
            DamageMultiplier = 0f;
            AttackSpeedMultiplier = 0f;
            BarrelType = BarrelType.Simple;
            BarrelModel = BarrelModel.SimpleBarrel;
            AdditionalShotsAmount = 0;

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Barrel";
        }

        public float DamageMultiplier { get; private set; }
        public float AttackSpeedMultiplier { get; private set; }
        public int AdditionalShotsAmount { get; private set; }
        public BarrelType BarrelType { get; private set; }
        public BarrelModel BarrelModel { get; private set; }

        public override float GetValue()
        {
            float value = 0;

            switch (Rang)
            {
                case Rang.Common:
                    value += value += CannonConfig.Barrel.BasicValueCommon;
                    break;
            }

            value += DamageMultiplier * CannonConfig.Barrel.DamageMultiplierValueMultiplier;
            value += AttackSpeedMultiplier * CannonConfig.Barrel.AttackSpeedMultiplierValueMultiplier;
            value += AdditionalShotsAmount * CannonConfig.Barrel.AdditionalProjectilesValueMultiplier;
            return value;
        }

        public class Builder : AbstractCannonPartBuilder<Barrel>
        {
            public Builder(uint id, Rang rang, BarrelModel model) : base(id, BarrelModelHelper.GetName(model), rang)
            {
                _cannonPart.BarrelType = BarrelModelHelper.GetType(model);
                _cannonPart.BarrelModel = model;
            }

            public Builder SetDamageMultiplier(float damageMultiplier)
            {
                _cannonPart.DamageMultiplier = damageMultiplier;
                return this;
            }

            public Builder SetAttackSpeedMultiplier(float attackSpeedMultiplier)
            {
                _cannonPart.AttackSpeedMultiplier = attackSpeedMultiplier;
                return this;
            }

            public Builder SetAdditionalShotsAmount(int additionalShotsAmount)
            {
                _cannonPart.AdditionalShotsAmount = additionalShotsAmount;
                return this;
            }
        }
    }
}