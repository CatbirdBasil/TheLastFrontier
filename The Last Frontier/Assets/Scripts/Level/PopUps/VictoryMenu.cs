using System;
using Level.LevelEventArgs;
using TLFGameLogic;
using TLFGameLogic.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Level.PopUps
{
    public class VictoryMenu : EndScreenMenu
    {
        public Text MoneyText;

        [Inject] private LevelStateManager _levelStateManager;
        private LevelInfo _levelInfo;

        private void OnEnable()
        {
            _levelInfo = _levelStateManager.LevelInfo;
            MoneyText.text = _levelInfo.Reward.ToString();
        }
    }
}