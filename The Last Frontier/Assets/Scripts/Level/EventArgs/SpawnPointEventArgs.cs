using System;
using System.Collections.Generic;
using Level.DTO;

namespace Level.LevelEventArgs
{
    public class SpawnPointEventArgs : EventArgs
    {
        public SpawnPointEventArgs(List<SpawnPointDTO> spawnPointDtos)
        {
            SpawnPointDtos = spawnPointDtos;
        }

        public List<SpawnPointDTO> SpawnPointDtos { get; }
    }
}