using TLFGameLogic.Model.CannonData.Enum;
using UnityEngine;

namespace Level.Cannon.Base
{
    public class CannonBaseSpriteResolver
    {
        private const string SpriteRoot = "Sprites/Cannon/CannonBases/";
        private const string SimpleBRegularGun = "SimpleRegularGun";

        public Sprite GetCannonBaseSprite(CannonBaseModel baseModel)
        {
            switch (baseModel)
            {
                case CannonBaseModel.SimpleRegularGun:
                    return GetSprite(SimpleBRegularGun);
            }

            return null;
        }

        private Sprite GetSprite(string spriteName)
        {
            return Resources.Load<Sprite>(SpriteRoot + spriteName);
        }
    }
}