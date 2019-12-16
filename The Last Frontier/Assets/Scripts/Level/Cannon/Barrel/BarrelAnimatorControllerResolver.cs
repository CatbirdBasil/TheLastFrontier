using TLFGameLogic.Model.CannonData.Enum;
using TLFGameLogic.Model.CannonData.Enum.Barrel;
using UnityEditor.Animations;
using UnityEngine;

namespace Level.Cannon.Barrel
{
    public class BarrelAnimatorControllerResolver
    {
        private const string AnimationRoot = "Animations/Cannon/Barrel";
        private const string DefaultControllerName = "/Barrel";
        private const string SimpleBarrel = "SimpleBarrel";

        public AnimatorController GetAnimatorController(BarrelModel barrelModel)
        {
            switch (barrelModel)
            {
                case BarrelModel.SimpleBarrel:
                    return GetController(SimpleBarrel);
            }

            return null;
        }

        private AnimatorController GetController(string controllerFolder)
        {
            return Resources.Load<AnimatorController>(AnimationRoot + controllerFolder + DefaultControllerName);
        }
    }
}