namespace TLFUILogic
{
    public class PlayerDataForSafe
    {
        public int[] BaseFragments;
        public int[] Level;
        public int Money;
        public int SpecialMoney;

        public PlayerDataForSafe(PlayerData playerData)
        {
            Money = playerData.money;
            SpecialMoney = playerData.specialMoney;
            //add levels
            Level = new int[playerData.level.Count];
            for (var i = 0; i < BaseFragments.Length; i++) Level[i] = playerData.level[i];

            //and inventory 
            BaseFragments = new int[playerData.BaseCannonFragments.Count];
            for (var i = 0; i < BaseFragments.Length; i++)
                BaseFragments[i] = (int) playerData.BaseCannonFragments[i].CannonBaseType;
        }
    }
}