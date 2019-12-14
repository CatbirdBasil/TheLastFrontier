using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFUILogic;

namespace TLFGameLogic.Model
{
    public class CannonBase : CannonPart
    {
        public float Damage { get; }
        public float AttackSpeed { get; }
        public ProjectileType ProjectileType { get; }
        public Ammo Ammo { get; }

        public CannonBaseType CannonBaseType { get; }
        public CannonBaseModel CannonBaseModel { get; }

        public CannonBase()
        {
            Damage = 6f;
            AttackSpeed = 1f;
            ProjectileType = ProjectileType.Bullet;
            CannonBaseType = CannonBaseType.RegularGun;
            CannonBaseModel = CannonBaseModel.SimpleRegularGun;
            Ammo = new Ammo();

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Base";
        }

        public CannonBase(float damage, float attackSpeed, ProjectileType projectileType, Ammo ammo,
            CannonBaseType cannonBaseType)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
            ProjectileType = projectileType;
            Ammo = ammo;
            CannonBaseType = cannonBaseType;
        }
        
        public override float GetValue()
        {
            float value = 0;

            switch (Rang)
            {
                case Rang.Common:
                    value += CannonConfig.CannonBase.BasicValueCommon;
                    break;
            }

            value += Damage * CannonConfig.CannonBase.DamageValueMultiplier;
            value += AttackSpeed * CannonConfig.CannonBase.AttackSpeedValueMultiplier;
            return value;
        }
    }
}