using System;
using Level.LevelEventArgs;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace Level
{
    public class SpawnManager : MonoBehaviour
    {
        private float _currentAbsoluteTime;
        private bool _isLoading;

        private LevelInfo _levelInfo;
        [Inject] private LevelLoader _levelLoader;

        private void Update()
        {
            if (!_isLoading)
            {
                // Chet takoi
            }
        }

        private void OnEnable()
        {
            _currentAbsoluteTime = 0;
            _isLoading = true;

            _levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoaded;
            _levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        private void OnDisable()
        {
            _levelLoader.LevelInfoLoadingCompleted -= OnLevelInfoLoaded;
            _levelLoader.LoadingCompleted -= OnLevelLoaded;
        }

        private void OnLevelInfoLoaded(object sender, LevelInfoEventArgs args)
        {
            _levelInfo = args.LevelInfo;
        }

        private void OnLevelLoaded(object sender, EventArgs args)
        {
            _isLoading = false;
        }
    }
}