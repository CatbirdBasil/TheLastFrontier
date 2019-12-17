using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFGameLogic.Model.CannonData.Config;

namespace TLFUILogic
{
    /// <summary>
    ///     General information about user and his inventory
    /// </summary>
    public class PlayerData
    {
        public List<int> Level { get; set; }
        public int Money { get; set; }
        public int SpecialMoney { get; set; }
        public int CurrentBase { get; set; }
        public int CurrentBarrel{ get; set; }
        public List<CannonBase> BaseCannonFragments { get; } //all base in inventory
        public List<Barrel> Barrels { get; } //all barrels in inventory
        
        //default date 
        public PlayerData()
        {
            Level = new List<int>();
            Money = 100;
            SpecialMoney = 0;
            BaseCannonFragments = new List<CannonBase>();
            Barrels = new List<Barrel>();
        }

        public PlayerData(PlayerDataForSafe data)
        {
            Level = new List<int>(data.Level);
            Money = data.Money;
            SpecialMoney = data.SpecialMoney;

            BaseCannonFragments = getAllBaseFromSaveFile(data);
            Barrels = getAllBarrelsFromSaveFile(data);
        }

        public List<CannonBase> getAllBaseFromSaveFile(PlayerDataForSafe data)
        {
            List<CannonBase> result = new List<CannonBase>();
            for (int i = 0; i < data.Damages.Length; i++)
            {
                CannonBase cannonBase = new CannonBase(data.Rangs[i],data.Damages[i], data.AttackSpeeds[i],
                data.ProjectileTypes[i],data.ProjectsSpeed[i],data.CannonBaseTypes[i]);
                result.Add(cannonBase);
            }
            return result;
        }

        public List<Barrel> getAllBarrelsFromSaveFile(PlayerDataForSafe data)
        {
            List<Barrel> result = new List<Barrel>();
            for (int i = 0; i < data.BarrelTypes.Length; i++)
            {
                Barrel barrel = new Barrel(data.DamageMultipliers[i],data.AttackSpeeds[i],data.AdditionalShotsAmounts[i],
                    data.BarrelTypes[i],data.BarrelModels[i]);
                result.Add(barrel);
            }
            return result;
        }

    }
    
    
}