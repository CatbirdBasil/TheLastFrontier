using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public class EnemyPrefabDictionary
    {
        private const string PrefabRoot = "Prefabs/Enemies/";
        private const string SmallSlimeName = "SmallSlime";

        public GameObject GetEnemyPrefab(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.SmallSlime:
                    return GetPrefab(SmallSlimeName);
            }

            return null;
        }

        private GameObject GetPrefab(string prefabName)
        {
            return Resources.Load<GameObject>(PrefabRoot + prefabName);
        }
    }
}