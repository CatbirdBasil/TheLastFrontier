using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;

namespace TLFUILogic
{
    /// <summary>
    ///     General information about user and his inventory
    /// </summary>
    public class PlayerData
    {
        private static PlayerData _instance;

        //default date 
        private PlayerData()
        {
            Level = new List<int>();
            Money = 1000;
            SpecialMoney = 0;
            BaseCannonFragments = new List<CannonBase>();
            Barrels = new List<Barrel>();
            _instance = this;
        }

        private PlayerData(PlayerDataForSafe data)
        {
            Level = new List<int>(data.Level);
            Money = data.Money;
            SpecialMoney = data.SpecialMoney;

            BaseCannonFragments = getAllBaseFromSaveFile(data);
            Barrels = getAllBarrelsFromSaveFile(data);
        }

        public List<int> Level { get; set; }
        public int Money { get; set; }
        public int SpecialMoney { get; set; }
        public int CurrentBase { get; set; }
        public int CurrentBarrel { get; set; }
        public List<CannonBase> BaseCannonFragments { get; } //all base in inventory
        public List<Barrel> Barrels { get; } //all barrels in inventory

        public static PlayerData Instance
        {
            get
            {
                if (_instance == null) _instance = new PlayerData();
                return _instance;
            }
        }

        public static void UpdatePlayerData(PlayerDataForSafe data)
        {
            _instance = new PlayerData(data);
        }


        public List<CannonBase> getAllBaseFromSaveFile(PlayerDataForSafe data)
        {
            var result = new List<CannonBase>();
            for (var i = 0; i < data.Damages.Length; i++)
            {
                var cannonBase = new CannonBase(data.Rangs[i], data.Damages[i], data.AttackSpeeds[i],
                    data.ProjectileTypes[i], data.ProjectsSpeed[i], data.CannonBaseTypes[i]);
                result.Add(cannonBase);
            }

            return result;
        }

        public List<Barrel> getAllBarrelsFromSaveFile(PlayerDataForSafe data)
        {
            var result = new List<Barrel>();
            for (var i = 0; i < data.BarrelTypes.Length; i++)
            {
                var barrel = new Barrel(data.DamageMultipliers[i], data.AttackSpeeds[i], data.AdditionalShotsAmounts[i],
                    data.BarrelTypes[i], data.BarrelModels[i]);
                result.Add(barrel);
            }

            return result;
        }
    }
}