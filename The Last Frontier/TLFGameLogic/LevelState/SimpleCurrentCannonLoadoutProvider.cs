using TLFGameLogic.Config;
using TLFGameLogic.Model;

namespace TLFGameLogic
{
    public class SimpleCurrentCannonLoadoutProvider : CurrentCannonLoadoutProvider
    {
        protected override Cannon GetCannon()
        {
            return DemoCannon.Get();
        }
    }
}