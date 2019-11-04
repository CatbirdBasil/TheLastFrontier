using System;
using Level.LevelEventArgs;
using TLFGameLogic;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelStateManager : MonoBehaviour
    {
        private LevelInfo _levelInfo;
        [Inject] private LevelLoader _levelLoader;

        public CurrentCannonLoadout CurrentCannonLoadout { get; private set; }

        private void OnEnable()
        {
            Debug.Log("State manager enabled");
            _levelLoader.CurrentCannonLoadoutLoadingCompleted += OnCurrentCannonLoadoutLoaded;
            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            //_levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        private void OnDisable()
        {
            Debug.Log("State manager disenabled");
            _levelLoader.CurrentCannonLoadoutLoadingCompleted -= OnCurrentCannonLoadoutLoaded;
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            //_levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
        }

        private void OnCurrentCannonLoadoutLoaded(object sender, CurrentCannonLoadoutEventArgs args)
        {
            CurrentCannonLoadout = args.CurrentCannonLoadout;
            Debug.Log("Cannon info passed to state manager");
        }

        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {
            _levelInfo = args.LevelInfo;
            _levelInfo.AllEnemiesDead += OnAllEnemiesDead;
        }

        private void OnAllEnemiesDead(object sender, EventArgs args)
        {
            // Show victory screen
        }
    }
}