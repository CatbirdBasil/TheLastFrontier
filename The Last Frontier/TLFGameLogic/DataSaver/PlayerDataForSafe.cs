using TLFGameLogic.Model;

namespace TLFUILogic
{
    public class PlayerDataForSafe
    {
        public int[] BaseFragments;
        public int CurrentLoadout;
        public int[] Level;
        public Cannon[] Loadouts;
        public int Money;
        public int SpecialMoney;

        public PlayerDataForSafe(PlayerData playerData)
        {
            Money = playerData.Money;
            SpecialMoney = playerData.SpecialMoney;

            CurrentLoadout = playerData.CurrentLoadout;
            Loadouts = new Cannon[playerData.Loadouts.Count];
            for (var i = 0; i < Loadouts.Length; i++)
                Loadouts[i] = playerData.Loadouts[i];

            //add levels
            Level = new int[playerData.Level.Count];
            for (var i = 0; i < BaseFragments.Length; i++) Level[i] = playerData.Level[i];

            //and inventory 
            BaseFragments = new int[playerData.BaseCannonFragments.Count];
            for (var i = 0; i < BaseFragments.Length; i++)
                BaseFragments[i] = (int) playerData.BaseCannonFragments[i].CannonBaseType;
        }
    }
}