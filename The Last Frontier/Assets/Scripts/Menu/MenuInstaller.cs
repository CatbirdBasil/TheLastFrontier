using Menu.Loader;
using Menu.Loader.Inventory;
using TLFGameLogic;
using TLFUILogic;
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
            Container.Bind<FileSaveSystem>().ToSelf().AsSingle().NonLazy();
            Container.Bind<ItemPicturesResolver>().ToSelf().AsSingle().NonLazy();
            Container.Bind<ILevelInfoProvider>().To<SimpleLevelInfoProvider>().AsSingle();
        }
    }
}