using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;

namespace TLFGameLogic.Config
{
    public class DemoCannon
    {
        public static Cannon Get()
        {
            var cannonBase = new CannonBase();
            var cannon = new Cannon();
            cannon.Base = cannonBase;
            cannon.Barrel = new Barrel();

            return cannon;
        }
    }
}