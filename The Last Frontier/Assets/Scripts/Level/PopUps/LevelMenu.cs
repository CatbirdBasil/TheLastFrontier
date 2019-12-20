using Intents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level.PopUps
{
    public abstract class LevelMenu : MonoBehaviour
    {
        protected void ChangeScene(int buildIndex, Intent intent, object payload = null)
        {
            IntentHolder.Instance.SetIntent(intent, payload);
            SceneManager.LoadScene(buildIndex);
        }

        public void OpenShop()
        {
            ChangeScene(SceneManager.GetActiveScene().buildIndex - 1, Intent.LoadShopMenu);
        }

        public void OpenMenu()
        {
            ChangeScene(SceneManager.GetActiveScene().buildIndex - 1, Intent.LoadLevelsMenu);
        }
    }
}