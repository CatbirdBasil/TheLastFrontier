using System;
using Level.LevelEventArgs;
using TLFGameLogic.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level.PopUps
{
    public class VictoryMenu : EndScreenMenu
    {
        public Text MoneyText;

        [Inject] private LevelLoader _levelLoader;
        private LevelInfo _levelInfo;

        VictoryMenu()
        {
            Debug.Log("Victory Menu init");
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