using TLFGameLogic.Model;
using UnityEngine;

namespace TLFUILogic
{
    public class SmallSlime : EnemyView
    {
        public SmallSlime(Enemy enemy, GameObject gameObject) //: base(enemy, gameObject)
        {
        }

        public GameObject Prefab { get; }
    }
}