using TLFGameLogic;
using TLFUILogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.Loader
{
    public class LevelsList:MonoBehaviour
    {
        public Transform contentPanel;
        [Inject] private FileSaveSystem _file;
        [Inject] private ILevelInfoProvider _levelInfoProvider;
        private PlayerData _player;


        void Start()
        {
            _player = _file.getInfo();
            RefreshDisplay();
        }

        void RefreshDisplay()
        {
            RemoveButtons();
            AddButtons ();
        }

        private void RemoveButtons()
        {
        }

        private void AddButtons()
        {
            int numberOfLevels = _levelInfoProvider.GetLevelAmount();
            GameObject butt = Resources.Load<GameObject>("Prefabs/Menu/Levels/LevelButton");
            for (int i = 1; i <= numberOfLevels; i++)
            {
                GameObject button = Instantiate(butt, contentPanel, false);
                if(_player.Level.Contains(i))
                    button.GetComponent<Image>().color = Color.white;
                LevelButton sampleButton =button.GetComponent<LevelButton>();
                Debug.Log(i);
                sampleButton.SetUp(i);
            }
        }
    }
}