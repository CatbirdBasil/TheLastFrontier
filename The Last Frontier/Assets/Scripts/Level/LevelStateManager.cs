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
            _levelLoader.CurrentCannonLoadoutLoadingCompleted += OnCurrentCannonLoadoutLoaded;
            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            //_levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        public CurrentCannonLoadout CurrentCannonLoadout { get; private set; }

        ~LevelStateManager()
        {
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            _levelLoader.CurrentCannonLoadoutLoadingCompleted -= OnCurrentCannonLoadoutLoaded;
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnCurrentCannonLoadoutLoaded(object sender, CurrentCannonLoadoutEventArgs args)
        {
            CurrentCannonLoadout = args.CurrentCannonLoadout;
            Debug.Log("Cannon info passed to state manager");

            _levelLoader.CurrentCannonLoadoutLoadingCompleted -= OnCurrentCannonLoadoutLoaded;
        }

        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {
            _levelInfo = args.LevelInfo;
            _levelInfo.AllEnemiesDead += OnAllEnemiesDead;

            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
        }

        private void OnAllEnemiesDead(object sender, EventArgs args)
        {
            // Show victory screen
        }
    }
}