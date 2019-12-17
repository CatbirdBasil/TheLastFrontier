using System;
using TLFGameLogic.Model;

namespace Level.LevelEventArgs
{
    public class LevelInfoEventArgs : EventArgs
    {
        public LevelInfoEventArgs(LevelInfo levelInfo)
        {
            LevelInfo = levelInfo;
        }

        public LevelInfo LevelInfo { get; }
    }
}