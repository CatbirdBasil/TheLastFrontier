using Level;
using TLFGameLogic;
using Zenject;

namespace TLFUILogic
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CurrentCannonLoadoutProvider>().To<SimpleCurrentCannonLoadoutProvider>().AsSingle();
            Container.Bind<ILevelInfoProvider>().To<SimpleLevelInfoProvider>().AsSingle();

            Container.Bind<LevelStateManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<LevelLoader>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

            Container.Bind<EnemyPrefabDictionary>().ToSelf().AsSingle();
            Container.Bind<IEnemyFactory>().To<SimpleEnemyFactory>().AsSingle();
        }
    }
}