using System.Collections.Generic;
using TLFGameLogic.Model;

namespace TLFUILogic
{
    /// <summary>
    ///     General information about user and his inventory
    /// </summary>
    public class PlayerData
    {
        //TODO add 2 more list for cannon parts 


        //default date 
        public PlayerData()
        {
            Level = new List<int>();
            Money = 100;
            SpecialMoney = 0;
            BaseCannonFragments = new List<CannonBase>();

            Loadouts = new List<Cannon>();
            CurrentLoadout = 0;
        }

        public PlayerData(PlayerDataForSafe data)
        {
            Level = new List<int>(data.Level);
            Money = data.Money;
            SpecialMoney = data.SpecialMoney;

            foreach (var baseType in data.BaseFragments)
            {
                //TODO create baseFragment from its type   
            }
        }

        public List<int> Level { get; set; }
        public int Money { get; set; }
        public int SpecialMoney { get; set; }
        public List<Cannon> Loadouts { get; set; }
        public int CurrentLoadout { get; set; }

        public List<CannonBase> BaseCannonFragments { get; }
    }
}