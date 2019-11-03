using Zenject;
using TLFGameLogic;

namespace TLFUILogic
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CurrentCannonLoadoutProvider>().To<SimpleCurrentCannonLoadoutProvider>().AsSingle();
            Container.Bind<ILevelInfoProvider>().To<SimpleLevelInfoProvider>().AsSingle();
        }
    }
}