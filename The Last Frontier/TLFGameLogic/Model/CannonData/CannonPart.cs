using TLFGameLogic.Model.CannonData.Enum;

namespace TLFUILogic
{
    public abstract class CannonPart
    {
        public uint Id { get; protected set; }
        public string Name { get; protected set; }
        public Rang Rang { get; protected set; }

        public abstract float GetValue();
    }
}