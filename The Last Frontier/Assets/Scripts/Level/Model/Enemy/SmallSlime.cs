using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public class SmallSlime : EnemyViewModel
    {
        public SmallSlime(Enemy enemy, GameObject gameObject) //: base(enemy, gameObject)
        {
        }

        public GameObject Prefab { get; }
    }
}