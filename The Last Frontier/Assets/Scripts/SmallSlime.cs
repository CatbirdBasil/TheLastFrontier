using System;
using TLFGameLogic.Model;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace TLFUILogic
{
    public class SmallSlime : EnemyView
    {
        public GameObject Prefab { get; }


        public SmallSlime(Enemy enemy, GameObject gameObject) : base(enemy, gameObject)
        {
        }
    }

}