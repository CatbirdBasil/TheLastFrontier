using TLFGameLogic.Model.CannonData.Enum;
using TLFGameLogic.Model.CannonData.Enum.Barrel;
using TLFUILogic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Loader.Inventory
{
    public class ItemPicturesResolver
    {
        private const string BarrelPrefabRoot = "Prefabs/Menu/Barrel";
        private const string BasePrefabRoot = "Prefabs/Menu/CannonBase";
        private const string SimpleBase = "/BasicCannonBaseIcon";
        private const string SimpleBarrel = "/SimpleBarrelIcon";
        private const string ModernBarrel = "/NewBarrel";
        

        public Sprite GetBarrelImage(BarrelType barrelType)
        {
            switch (barrelType)
            {
                case BarrelType.Simple:
                    return GetImagePrefab(BarrelPrefabRoot,SimpleBarrel);
                case BarrelType.Modern:
                    return GetImagePrefab(BarrelPrefabRoot, ModernBarrel);
            }

            return null;
        }
        
        
        public Sprite GetBaseImage(CannonBaseType cannonBaseType)
        {
            switch (cannonBaseType)
            {
                case CannonBaseType.RegularGun:
                    return GetImagePrefab(BasePrefabRoot,SimpleBase);
            }
            return null;
        }

        private Sprite GetImagePrefab(string path,string prefabName)
        {
            return Resources.Load<Sprite>(path + prefabName);
        }
        
     
    }
}