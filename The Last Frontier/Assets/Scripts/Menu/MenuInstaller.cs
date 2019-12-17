using Menu.Loader;
using Zenject;

namespace Menu
{
    public class MenuInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MenuLoader>().ToSelf().AsSingle().NonLazy();
            Container.Bind<InventorySceneLoader>().ToSelf().AsSingle().NonLazy();
            Container.Bind<LevelsSceneLoader>().ToSelf().AsSingle();
            Container.Bind<StoreSceneLoader>().ToSelf().AsSingle().NonLazy();
        }
    }
}