using System;
using System.Collections.Generic;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFGameLogic.Model.CannonData.Enum.Barrel;
using TLFGameLogic.Utils;
using TLFUILogic;

namespace TLFGameLogic.Model
{
    public class CannonPartFactory
    {
        public CannonPart GetCommonBoxPart()
        {
            var rang = ChooseRang(new Dictionary<Rang, double>
            {
                {Rang.Common, 0.9f},
                {Rang.Uncommon, 0.1f}
            });

            var partToGet = new Random().Next(0, 2);

            switch (partToGet)
            {
                case 0: return GetCannonBase(rang);
                case 1: return GetBarrel(rang);
                default: return null;
            }
        }

        private CannonBase GetCannonBase(Rang rang)
        {
            var amountOfModels = Enum.GetNames(typeof(CannonBaseModel)).Length;
            var chosenModelIndex = new Random().Next(0, amountOfModels);
            CannonBaseModel model;
            Enum.TryParse(Enum.GetNames(typeof(CannonBaseModel))[chosenModelIndex], out model);

            return new CannonBase.Builder( /* MAKE ID GENERATOR */0, rang, model)
                .SetDamage(GetRandomValue(CannonConfig.CannonBase.DamageMinCommon,
                    CannonConfig.CannonBase.DamageMaxCommon))
                .SetAttackSpeed(GetRandomValue(CannonConfig.CannonBase.AttackSpeedMinCommon,
                    CannonConfig.CannonBase.AttackSpeedMaxCommon))
                .SetProjectileSpeed(GetRandomValue(CannonConfig.CannonBase.ProjectileSpeedMinCommon,
                    CannonConfig.CannonBase.ProjectileSpeedMaxCommon))
                .Build();
        }

        private Barrel GetBarrel(Rang rang)
        {
            var amountOfModels = Enum.GetNames(typeof(BarrelModel)).Length;
            var chosenModelIndex = new Random().Next(0, amountOfModels);
            BarrelModel model;
            Enum.TryParse(Enum.GetNames(typeof(BarrelModel))[chosenModelIndex], out model);

            return new Barrel.Builder( /* MAKE ID GENERATOR */0, rang, model)
                .SetDamageMultiplier(GetRandomValue(CannonConfig.Barrel.DamageMultiplierMinCommon,
                    CannonConfig.Barrel.DamageMultiplierMaxCommon))
                .SetAttackSpeedMultiplier(GetRandomValue(CannonConfig.Barrel.AttackSpeedMultiplierMinCommon,
                    CannonConfig.Barrel.AttackSpeedMultiplierMaxCommon))
                .SetAdditionalShotsAmount(0) //TODO Add MultiBarrelSupport
                .Build();
        }

        private Rang ChooseRang(Dictionary<Rang, double> chances)
        {
            var rangRandNumber = new Random().NextDouble();

            double currRangBottomBorder = 0;
            double currRangUpperBorder = 0;
            foreach (var rangChance in chances)
            {
                currRangUpperBorder += rangChance.Value;
                if (rangRandNumber >= currRangBottomBorder && rangRandNumber < currRangUpperBorder)
                    return rangChance.Key;

                currRangBottomBorder = currRangUpperBorder;
            }

            return Rang.Common;
        }

        private float GetRandomValue(float minValue, float maxValue)
        {
            var sigma = (maxValue - minValue) / 2;
            return RandomUtils.NextGauss(minValue + sigma, sigma);
        }
    }
}