using Intents;
using TLFGameLogic.Model;
using TLFUILogic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Level.PopUps
{
    public class VictoryMenu : LevelMenu
    {
        [Inject] private FileSaveSystem _file;
        private LevelInfo _levelInfo;

        [Inject] private LevelStateManager _levelStateManager;
        public Text MoneyText;

        private void OnEnable()
        {
            _levelInfo = _levelStateManager.LevelInfo;
            MoneyText.text = _levelInfo.Reward.ToString();
            PlayerData.Instance.Money += _levelInfo.Reward;
            //var _player = _file.getInfo();
            // _player.Level.Add(_levelInfo.LevelNumber);
            //_file.saveInfo(_player);
            //_levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoadingCompleted;
        }

        public void RunNextLevel()
        {
            ChangeScene(SceneManager.GetActiveScene().buildIndex, Intent.LoadLevel, _levelInfo.LevelNumber + 1);
        }
    }
}