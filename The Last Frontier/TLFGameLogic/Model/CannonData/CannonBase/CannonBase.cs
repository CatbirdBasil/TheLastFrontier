using TLFGameLogic.Model.CannonData.CannonBase;
using TLFGameLogic.Model.CannonData.Config;
using TLFGameLogic.Model.CannonData.Enum;
using TLFUILogic;

namespace TLFGameLogic.Model
{
    public class CannonBase : CannonPart
    {
        public CannonBase()
        {
            Damage = 7f;
            AttackSpeed = 1f;
            ProjectileType = ProjectileType.Bullet;
            CannonBaseType = CannonBaseType.RegularGun;
            CannonBaseModel = CannonBaseModel.SimpleRegularGun;
            ProjectileSpeed = 10f;

            //TODO make parametrised constructor and factory
            Id = 0;
            Name = "Regular Cannon Base";
        }

        public CannonBase(int id, string name, Rang rang, float damage, float attackSpeed,
            ProjectileType projectileType, float projectileSpeed,
            CannonBaseType cannonBaseType)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
            ProjectileType = projectileType;
            ProjectileSpeed = projectileSpeed;
            CannonBaseType = cannonBaseType;
        }

        public float Damage { get; }
        public float AttackSpeed { get; }
        public ProjectileType ProjectileType { get; }
        public float ProjectileSpeed { get; }
        public CannonBaseType CannonBaseType { get; }
        public CannonBaseModel CannonBaseModel { get; }

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
            value += ProjectileSpeed * CannonConfig.CannonBase.ProjectileSpeedValueMultiplier;
            return value;
        }

        public class Builder : AbstractCannonPartBuilder<CannonBase>
        {
            public Builder(uint id, Rang rang, CannonBaseModel model) : base(id, CannonBaseModelHelper.GetName(model),
                rang)
            {
                _cannonPart.CannonBaseType = CannonBaseModelHelper.GetType(model);
                _cannonPart.ProjectileType = CannonBaseModelHelper.GetProjectileType(model);
                _cannonPart.CannonBaseModel = model;
            }

            public Builder SetDamage(float damage)
            {
                _cannonPart.Damage = damage;
                return this;
            }

            public Builder SetAttackSpeed(float attackSpeed)
            {
                _cannonPart.AttackSpeed = attackSpeed;
                return this;
            }

            public Builder SetProjectileSpeed(float projectileSpeed)
            {
                _cannonPart.ProjectileSpeed = projectileSpeed;
                return this;
            }
        }
    }
}