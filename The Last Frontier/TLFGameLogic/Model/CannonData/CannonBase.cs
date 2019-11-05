using TLFUILogic;

namespace TLFGameLogic.Model
{
    public class CannonBase : CannonFragment
    {
        public uint Id { get; }
        public string Name { get; }
        public float Damage { get; }
        public float AttackSpeed { get; }
        public ProjectileType ProjectileType { get; }
        public Ammo Ammo { get; }

        public TypeOfCannonBase TypeOfCannonBase { get; }

        public CannonBase()
        {
            Damage = 5f;
            AttackSpeed = 1f;
            ProjectileType = ProjectileType.Bullet;
            Ammo = new Ammo();

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Base";
        }
    }
}