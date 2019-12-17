using System.Collections.Generic;
using System.Linq;
using TLFGameLogic.Model;

namespace TLFUILogic
{
    /// <summary>
    /// General information about user and his inventory 
    /// </summary>
    public class PlayerData
    {
        public List<int> level { get; set; }
        public int money { get; set; }
        public int specialMoney { get; set; }

        public List<CannonBase> BaseCannonFragments { get; }
        //TODO add 2 more list for cannon parts 
        
        


        //default date 
        public PlayerData()
        {
            level = new List<int>();
            money = 100;
            specialMoney = 0;
            BaseCannonFragments = new List<CannonBase>();
        }

        public PlayerData(PlayerDataForSafe data)
        {
            level = new List<int>(data.Level);
            money = data.Money;
            specialMoney = data.SpecialMoney;

            foreach (int baseType in data.BaseFragments)
            {
                //TODO create baseFragment from its type   
            }
        }
    }
}