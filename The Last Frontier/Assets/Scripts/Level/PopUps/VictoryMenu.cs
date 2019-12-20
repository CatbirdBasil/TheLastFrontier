using System;
using Level.LevelEventArgs;
using TLFGameLogic.Model;
using TLFUILogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level.PopUps
{
    public class VictoryMenu : EndScreenMenu
    {
        public Text MoneyText;

        [Inject] private LevelLoader _levelLoader;
        [Inject] private FileSaveSystem _file;
        private LevelInfo _levelInfo;

        VictoryMenu()
        {
            Debug.Log("Victory Menu init");
            PlayerData _player = _file.getInfo();
            _player.Level.Add(_levelInfo.Level);
            //_file.saveInfo(_player);
            //_levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoadingCompleted;
        }

        ~VictoryMenu()
        {
            //_levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoadingCompleted;
        }

        private void OnLevelInfoLoadingCompleted(object sender, LevelInfoEventArgs e)
        {
            _levelInfo = e.LevelInfo;
        }
    }
}