using TLFGameLogic.Model;

namespace TLFGameLogic.Config
{
    public class DemoCannon
    {
        public static Cannon Get()
        {
            var cannonBase = new CannonBase();
            var cannon = new Cannon();
            cannon.Base = cannonBase;

            return cannon;
        }
    }
}