using Level.LevelEventArgs;
using UnityEngine;
using Zenject;

namespace Level.Cannon.Barrel
{
    public class BarrelView : MonoBehaviour
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
            gameObject.GetComponent<SpriteRenderer>().sprite = e.BarrelSprite;
            gameObject.GetComponent<Animator>().runtimeAnimatorController = e.AnimatorController;
        }
    }
}