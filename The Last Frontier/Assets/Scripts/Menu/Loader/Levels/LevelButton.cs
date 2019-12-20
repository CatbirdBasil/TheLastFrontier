using Intents;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.Loader
{
    public class LevelButton : MonoBehaviour
    {
        private int _level;
        public Button Item;
        public TextMeshProUGUI LevelText;
        private Color normalColor;
        private bool notNirmalColor = false;

        private void Start()
        {
            LevelText.text = _level.ToString();
        }

        public void SetUp(int Level)
        {
            _level = Level;
        }

        public void HandleClick()
        {
            Debug.Log(_level);
            IntentHolder.Instance.SetIntent(Intent.LoadLevel, _level);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}