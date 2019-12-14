using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFUILogic;

namespace TLFGameLogic.Model.CannonData
{
    public class Barrel : CannonPart
    {
        public Barrel()
        {
            DamageMultiplier = 0f;
            AttackSpeedMultiplier = 0f;
            BarrelType = BarrelType.Simple;
            BarrelModel = BarrelModel.SimpleBarrel;

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Barrel";
        }

        public float DamageMultiplier { get; }
        public float AttackSpeedMultiplier { get; }
        public int AdditionalShotsAmount { get; }
        public BarrelType BarrelType { get; }
        public BarrelModel BarrelModel { get; }

        public override float GetValue()
        {
            float value = 0;

            switch (Rang)
            {
                case Rang.Common:
                    value += value += CannonConfig.CannonBarrel.BasicValueCommon;
                    break;
            }

            value += DamageMultiplier * CannonConfig.CannonBarrel.DamageMultiplierValueMultiplier;
            value += AttackSpeedMultiplier * CannonConfig.CannonBarrel.AttackSpeedMultiplierValueMultiplier;
            value += AdditionalShotsAmount * CannonConfig.CannonBarrel.AdditionalProjectilesValueMultiplier;
            return value;
        }
    }
}