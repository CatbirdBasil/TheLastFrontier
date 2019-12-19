using Level.LevelEventArgs;
using UnityEngine;
using Zenject;

namespace Level.Cannon.Barrel
{
    public class CannonViewInitializer : MonoBehaviour
    {
        [Inject] private readonly LevelLoader _levelLoader;

        private void OnEnable()
        {
            _levelLoader.BarrelLoadingCompleted += OnBarrelLoadingCompleted;
        }

        private void OnDisable()
        {
            _levelLoader.BarrelLoadingCompleted -= OnBarrelLoadingCompleted;
        }

        private void OnBarrelLoadingCompleted(object sender, BarrelEventArgs e)
        {
            GameObject barrel = Instantiate(e.BarrelPrefab, transform);
            barrel.transform.parent = transform;
        }
    }
}