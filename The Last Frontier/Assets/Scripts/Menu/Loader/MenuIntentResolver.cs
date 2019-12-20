using System;
using Intents;
using Zenject;

namespace Menu.Loader
{
    public class MenuIntentResolver : IntentResolver
    {
        [Inject] private MenuLoader _loader;

        public override void Resolve(Intent intent, object payload)
        {
            switch (intent)
            {
                case Intent.LoadLevelsMenu:
                    _loader.SceneType = MenuSceneType.Levels;
                    return;
                case Intent.LoadInventoryMenu:
                    _loader.SceneType = MenuSceneType.Inventory;
                    return;
                case Intent.LoadShopMenu:
                    _loader.SceneType = MenuSceneType.Shop;
                    return;
                default:
                    throw new ArgumentException("Inapplicable intent used (" + intent + ")");
            }
        }
    }
}