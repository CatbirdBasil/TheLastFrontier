using TLFGameLogic.Model.CannonData.Enum;
using UnityEngine;

namespace Level.Cannon.Barrel
{
    public class BarrelSpriteResolver
    {
        private const string SpriteRoot = "Sprites/Barrels/";
        private const string SimpleBarrel = "SimpleBarrel";

        public Sprite GetBarrelSprite(BarrelModel barrelModel)
        {
            switch (barrelModel)
            {
                case BarrelModel.SimpleBarrel:
                    return GetSprite(SimpleBarrel);
            }

            return null;
        }

        private Sprite GetSprite(string spriteName)
        {
            return Resources.Load<Sprite>(SpriteRoot + spriteName);
        }
    }
}