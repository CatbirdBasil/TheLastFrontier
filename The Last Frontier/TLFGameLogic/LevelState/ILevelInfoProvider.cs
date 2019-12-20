using TLFGameLogic.Model;

namespace TLFGameLogic
{
    public interface ILevelInfoProvider
    {
        LevelInfo GetLevel(int level);

        int GetLevelAmount();
    }
}