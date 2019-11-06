using TLFGameLogic.Model.LevelData;
using UnityEngine;

namespace Level.DTO
{
    public class SpawnPointDTO
    {
        public SpawnPointDTO(Transform transform, SpawnPoint spawnPointIdentifier)
        {
            Transform = transform;
            SpawnPointIdentifier = spawnPointIdentifier;
        }

        public Transform Transform { get; set; }
        public SpawnPoint SpawnPointIdentifier { get; set; }
    }
}