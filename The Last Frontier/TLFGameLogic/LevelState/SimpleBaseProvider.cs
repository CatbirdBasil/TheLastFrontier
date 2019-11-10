using TLFGameLogic.Model.BaseData;

namespace TLFGameLogic
{
    public class SimpleBaseProvider : IBaseProvider
    {
        public Base GetBase()
        {
            return new Base();
        }
    }
}