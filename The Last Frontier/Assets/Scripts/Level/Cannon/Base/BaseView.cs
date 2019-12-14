using Level.LevelEventArgs;
using UnityEngine;
using Zenject;

namespace Level.Cannon.Base
{
    public class BaseView : MonoBehaviour
    {
        [Inject] private readonly LevelLoader _levelLoader;

        private void OnEnable()
        {
            _levelLoader.CannonBaseLoadingCompleted += OnCannonBaseLoadingCompleted;
        }

        private void OnDisable()
        {
            _levelLoader.CannonBaseLoadingCompleted -= OnCannonBaseLoadingCompleted;
        }

        private void OnCannonBaseLoadingCompleted(object sender, CannonBaseEventArgs e)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = e.CannonBaseSprite;
        }
    }
}