using Level.LevelEventArgs;
using TLFGameLogic.Model.LevelData;
using UnityEngine;
using Zenject;

namespace Level.EnemySpawning
{
    public class SpawnPointResolver
    {
        private readonly LevelLoader _levelLoader;

        private Transform _spawnPointA;
        private Transform _spawnPointB;
        private Transform _spawnPointC;
        private Transform _spawnPointD;
        private Transform _spawnPointE;
        private Transform _spawnPointF;
        private Transform _spawnPointG;

        [Inject]
        public SpawnPointResolver(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
            _levelLoader.SpawnPointsLoadingCompleted += OnSpawnPointsLoaded;
        }

        ~SpawnPointResolver()
        {
            _levelLoader.SpawnPointsLoadingCompleted -= OnSpawnPointsLoaded;
        }

        public Transform GetSpawnPointTransform(SpawnPoint spawnPoint)
        {
            switch (spawnPoint)
            {
                case SpawnPoint.A:
                    return _spawnPointA;
                case SpawnPoint.B:
                    return _spawnPointB;
                case SpawnPoint.C:
                    return _spawnPointC;
                case SpawnPoint.D:
                    return _spawnPointD;
                case SpawnPoint.E:
                    return _spawnPointE;
                case SpawnPoint.F:
                    return _spawnPointF;
                case SpawnPoint.G:
                    return _spawnPointG;
            }

            return null;
        }

        private void OnSpawnPointsLoaded(object sender, SpawnPointEventArgs args)
        {
            var spawnPointDtos = args.SpawnPointDtos;

            _spawnPointA = spawnPointDtos.Find(x => SpawnPoint.A.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointB = spawnPointDtos.Find(x => SpawnPoint.B.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointC = spawnPointDtos.Find(x => SpawnPoint.C.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointD = spawnPointDtos.Find(x => SpawnPoint.D.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointE = spawnPointDtos.Find(x => SpawnPoint.E.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointF = spawnPointDtos.Find(x => SpawnPoint.F.Equals(x.SpawnPointIdentifier))?.Transform;
            _spawnPointG = spawnPointDtos.Find(x => SpawnPoint.G.Equals(x.SpawnPointIdentifier))?.Transform;

            _levelLoader.SpawnPointsLoadingCompleted -= OnSpawnPointsLoaded;
        }
    }
}