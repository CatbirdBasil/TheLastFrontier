using System;
using TLFGameLogic.Model.BaseData;

namespace Level.LevelEventArgs
{
    public class BaseEventArgs : EventArgs
    {
        public BaseEventArgs(Base currentBase)
        {
            CurrentBase = currentBase;
        }

        public Base CurrentBase { get; }
    }
}