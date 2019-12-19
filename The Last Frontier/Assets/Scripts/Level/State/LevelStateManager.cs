using System;
using Level.LevelEventArgs;
using Level.PopUps;
using TLFGameLogic;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelStateManager
    {
        private readonly LevelLoader _levelLoader;
        public LevelInfo LevelInfo;

        [Inject]
        public LevelStateManager(LevelLoader levelLoader)
        {
            Debug.Log("State manager enabled");

            _levelLoader = levelLoader;
            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            _levelLoader.BaseLoadingCompleted += OnBaseLoaded;
            //_levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        ~LevelStateManager()
        {
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            _levelLoader.BaseLoadingCompleted += OnBaseLoaded;
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }
        
        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {

            LevelInfo = args.LevelInfo;
            LevelInfo.AllEnemiesDead += OnAllEnemiesDead;
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
//            _base.CurrentBase.LethalDamage+= OnDefeat;
        }
        
        private void OnBaseLoaded(object sender, BaseEventArgs args)
        {
            args.CurrentBase.LethalDamage += OnBaseDestroyed;
        }


        private void OnBaseDestroyed(object sender, EventArgs args)
        {
            Debug.Log("DEFEAT");
            // Show victory screen
            EndScreenMenuPresenter.ShowDefeatScreen();
        }
        
        private void OnAllEnemiesDead(object sender, EventArgs args)
        {
            Debug.Log("VICTORY");
            // Show victory screen
            EndScreenMenuPresenter.ShowVictoryScreen();
        }
    }
}