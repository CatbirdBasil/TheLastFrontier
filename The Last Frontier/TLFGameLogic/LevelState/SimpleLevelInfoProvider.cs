using TLFGameLogic.Config;
using TLFGameLogic.Model;

namespace TLFGameLogic
{
    public class SimpleLevelInfoProvider : ILevelInfoProvider
    {
        public LevelInfo GetLevel(int level)
        {
            return Levels.Get(level);
        }
    }
}