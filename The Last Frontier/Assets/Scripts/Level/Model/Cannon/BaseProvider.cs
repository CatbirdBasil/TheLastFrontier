
using Level.LevelEventArgs;
using TLFGameLogic.Model.BaseData;
using UnityEngine;
using Zenject;

namespace Level
{
    public class BaseProvider
    {
        private readonly LevelLoader _levelLoader;
        public Base CurrentBase { get; set; }

        [Inject]
        public BaseProvider(LevelLoader levelLoader)
        {
            Debug.Log("State manager enabled");

            _levelLoader = levelLoader;
            _levelLoader.BaseLoadingCompleted += OnBaseLoaded;
        }

        ~BaseProvider()
        {
            _levelLoader.BaseLoadingCompleted += OnBaseLoaded;
        }


        private void OnBaseLoaded(object sender, BaseEventArgs args)
        {
            CurrentBase = args.CurrentBase;
        }
    }
}