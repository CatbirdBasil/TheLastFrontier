using Level;
using Level.Cannon;
using Level.Cannon.Barrel;
using Level.Cannon.Base;
using Level.EnemySpawning;
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
            Container.Bind<IBaseProvider>().To<SimpleBaseProvider>().AsSingle();

//            Container.Bind<LevelStateManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
//            Container.Bind<LevelLoader>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            Container.Bind<LevelLoader>().ToSelf().AsSingle().NonLazy();
            Container.Bind<SpawnPointResolver>().ToSelf().AsSingle();
            Container.Bind<LevelStateManager>().ToSelf().AsSingle().NonLazy();
            Container.Bind<PlayerState>().ToSelf().AsSingle().NonLazy();

            Container.Bind<EnemyPrefabDictionary>().ToSelf().AsSingle();
            Container.Bind<IEnemyFactory>().To<SimpleEnemyFactory>().AsSingle();

            Container.Bind<BulletPrefabResolver>().ToSelf().AsSingle();
            Container.Bind<IBulletFactory>().To<SimpleBulletFactory>().AsSingle();
            
            Container.Bind<BarrelSpriteResolver>().ToSelf().AsSingle();
            Container.Bind<BarrelAnimatorControllerResolver>().ToSelf().AsSingle();
            Container.Bind<CannonBaseSpriteResolver>().ToSelf().AsSingle();
        }
    }
}