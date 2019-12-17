using System;
using UnityEngine;

namespace Level.LevelEventArgs
{
    public class CannonBaseEventArgs : EventArgs
    {
        public CannonBaseEventArgs(Sprite cannonBaseSprite)
        {
            CannonBaseSprite = cannonBaseSprite;
        }

        public Sprite CannonBaseSprite { get; }
    }
}