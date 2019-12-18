using System;
using UnityEngine;

namespace Level.LevelEventArgs
{
    public class BarrelEventArgs : EventArgs
    {
        public BarrelEventArgs(GameObject barrelPrefab)
        {
            BarrelPrefab = barrelPrefab;
        }

        public GameObject BarrelPrefab { get; }
    }
}