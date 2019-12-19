using System;
using Level.LevelEventArgs;
using TLFGameLogic;
using TLFGameLogic.Model.BaseData;
using UnityEngine;
using Zenject;

namespace Level
{
    public class PlayerState
    {
        private readonly LevelLoader _levelLoader;

        [Inject]
        public PlayerState(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
            _levelLoader.CurrentCannonLoadoutLoadingCompleted += OnCurrentCannonLoadoutLoaded;
            _levelLoader.BaseLoadingCompleted += OnBaseLoaded;
            //_levelLoader.LoadingCompleted += OnLevelLoaded;
        }

        public CurrentCannonLoadout CurrentCannonLoadout { get; private set; }
        public Base CurrentBase { get; private set; }

        ~PlayerState()
        {
            _levelLoader.CurrentCannonLoadoutLoadingCompleted -= OnCurrentCannonLoadoutLoaded;
            _levelLoader.BaseLoadingCompleted -= OnBaseLoaded;
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

        private void OnBaseLoaded(object sender, BaseEventArgs args)
        {
            Debug.Log("Base loaded");
            CurrentBase = args.CurrentBase;

            _levelLoader.BaseLoadingCompleted -= OnBaseLoaded;
        }
    }
}