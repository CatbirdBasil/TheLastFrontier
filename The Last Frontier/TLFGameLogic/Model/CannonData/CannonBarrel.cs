using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFUILogic;

namespace TLFGameLogic.Model.CannonData
{
    public class CannonBarrel : CannonPart
    {
        public CannonBarrel()
        {
            DamageMultipier = 0f;
            AttackSpeedMultiplier = 0f;
            CannonBaseType = CannonBaseType.RegularGun;

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Barrel";
        }

        public float DamageMultipier { get; }
        public float AttackSpeedMultiplier { get; }
        public int AdditionalShotsAmount { get; }
        public CannonBaseType CannonBaseType { get; }

        public override float GetValue()
        {
            float value = 0;

            switch (Rang)
            {
                case Rang.Common:
                    value += value += CannonConfig.CannonBarrel.BasicValueCommon;
                    break;
            }

            value += DamageMultipier * CannonConfig.CannonBarrel.DamageMultiplierValueMultiplier;
            value += AttackSpeedMultiplier * CannonConfig.CannonBarrel.AttackSpeedMultiplierValueMultiplier;
            value += AdditionalShotsAmount * CannonConfig.CannonBarrel.AdditionalProjectilesValueMultiplier;
            return value;
        }
    }
}