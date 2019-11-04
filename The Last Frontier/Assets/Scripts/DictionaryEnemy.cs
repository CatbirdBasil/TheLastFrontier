using System.Collections.Generic;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace TLFUILogic
{
    public class DictionaryEnemy : MonoBehaviour
    {

        [SerializeField] private  GameObject SmallSlimePrefab;

        public  GameObject getEnemyPrefab(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case (EnemyType.SmallSlime):
                    return SmallSlimePrefab;
            }

            return null;
        }
    }
}