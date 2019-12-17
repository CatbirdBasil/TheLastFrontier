using System;
using TLFGameLogic;

namespace Level.LevelEventArgs
{
    public class CurrentCannonLoadoutEventArgs : EventArgs
    {
        public CurrentCannonLoadoutEventArgs(CurrentCannonLoadout currentCannonLoadout)
        {
            CurrentCannonLoadout = currentCannonLoadout;
        }

        public CurrentCannonLoadout CurrentCannonLoadout { get; }
    }
}