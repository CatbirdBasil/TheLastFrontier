using TLFGameLogic.Model;
using TLFUILogic;
using UnityEngine;

namespace Level.Cannon
{
    public class BulletPrefabResolver
    {
        private const string PrefabRoot = "Prefabs/Bullets/";
        private const string TestBullet = "TestBullet";

        public GameObject GetBulletPrefab(CannonBaseType cannonBaseType)
        {
            switch (cannonBaseType)
            {
                case CannonBaseType.RegularGun:
                    return GetPrefab(TestBullet);
            }

            return null;
        }

        private GameObject GetPrefab(string prefabName)
        {
            return Resources.Load<GameObject>(PrefabRoot + prefabName);
        }
    }
}