using System;
using Level.LevelEventArgs;
using TLFGameLogic;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelStateManager
    {
        private readonly LevelLoader _levelLoader;
        private LevelInfo _levelInfo;

        [Inject]
        public LevelStateManager(LevelLoader levelLoader)
        {
            Debug.Log("State manager enabled");

            _levelLoader = levelLoader;
            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            //_levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        ~LevelStateManager()
        {
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }
        
        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {
            _levelInfo = args.LevelInfo;
            _levelInfo.AllEnemiesDead += OnAllEnemiesDead;

            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
        }

        private void OnDefeat(object sender, EventArgs args)
        {
            Debug.Log("DEFEAT");
            // Show victory screen
        }
        
        private void OnAllEnemiesDead(object sender, EventArgs args)
        {
            Debug.Log("VICTORY");
            // Show victory screen
        }
    }
}