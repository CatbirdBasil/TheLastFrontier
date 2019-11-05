namespace TLFUILogic
{
    public interface ISaveSystem
    {
        void saveInfo(PlayerData playerData);

        PlayerData getInfo();
    }
}