using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Enum.Barrel;
using UnityEngine;

namespace Level.Cannon.Barrel
{
    public class BarrelPrefabResolver
    {
        private const string PrefabRoot = "Prefabs/Cannon/Barrels/";
        private const string SimpleBarrel = "SimpleBarrel";

        public GameObject GetBarrelPrefab(BarrelModel barrelModel)
        {
            switch (barrelModel)
            {
                case BarrelModel.SimpleBarrel:
                    return GetPrefab(SimpleBarrel);
            }

            return null;
        }

        private GameObject GetPrefab(string prefabName)
        {
            return Resources.Load<GameObject>(PrefabRoot + prefabName);
        }
    }
}