using System;
using UnityEditor.Animations;
using UnityEngine;

namespace Level.LevelEventArgs
{
    public class BarrelEventArgs : EventArgs
    {
        public BarrelEventArgs(Sprite barrelSprite, AnimatorController animatorController)
        {
            BarrelSprite = barrelSprite;
            AnimatorController = animatorController;
        }

        public Sprite BarrelSprite { get; }
        public AnimatorController AnimatorController { get; }
    }
}