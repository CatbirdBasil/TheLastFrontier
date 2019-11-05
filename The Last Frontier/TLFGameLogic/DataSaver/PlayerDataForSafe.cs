namespace TLFUILogic
{
    public class PlayerDataForSafe
    {
        public int[] Level;
        public int Money;
        public int SpecialMoney;
        public int[] BaseFragments;

        public PlayerDataForSafe(PlayerData playerData)
        {
            Money = playerData.money;
            SpecialMoney = playerData.specialMoney;
            //add levels
            Level = new int[playerData.level.Count];
            for (int i = 0; i < BaseFragments.Length; i++)
            {
                Level[i] = (int) playerData.level[i];
            }

            //and inventory 
            BaseFragments = new int[playerData.BaseCannonFragments.Count];
            for (int i = 0; i < BaseFragments.Length; i++)
            {
                BaseFragments[i] = (int) playerData.BaseCannonFragments[i].TypeOfCannonBase;
            }
        }

    }
}