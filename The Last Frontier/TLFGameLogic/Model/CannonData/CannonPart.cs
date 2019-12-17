using TLFGameLogic.Model.CannonData.Enum;

namespace TLFUILogic
{
    public abstract class CannonPart
    {
        public uint Id { get; protected set; }
        public string Name { get; protected set; }
        public Rang Rang { get; protected set; }

        public abstract float GetValue();

        public abstract class AbstractCannonPartBuilder<T> where T : CannonPart, new()
        {
            protected T _cannonPart;

            protected AbstractCannonPartBuilder(uint id, string name, Rang rang)
            {
                _cannonPart = new T();
                _cannonPart.Id = id;
                _cannonPart.Name = name;
                _cannonPart.Rang = rang;
            }

            public T Build()
            {
                return _cannonPart;
            }
        }
    }
}