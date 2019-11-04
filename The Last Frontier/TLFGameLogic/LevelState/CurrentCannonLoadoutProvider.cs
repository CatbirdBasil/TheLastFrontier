using TLFGameLogic.Model;

namespace TLFGameLogic
{
    // TODO Use refactored CurrentCannonLoadout Builder
    public abstract class CurrentCannonLoadoutProvider
    {
        private float _attackSpeed;
        private float _damage;
        private float _projectileSpeed;
        private ProjectileType _projectileType;

        public CurrentCannonLoadout GetLoadout()
        {
            var cannon = GetCannon();
            ExtractParameters(cannon);
            return new CurrentCannonLoadout(_damage, _attackSpeed, _projectileType, _projectileSpeed, cannon);
        }

        protected abstract Cannon GetCannon();

        protected void ExtractParameters(Cannon cannon)
        {
            _damage = 0;
            _attackSpeed = 0;
            _projectileSpeed = 0;

            _damage += cannon.Base.Damage;
            _attackSpeed += cannon.Base.AttackSpeed;
            _projectileType = cannon.Base.ProjectileType;

            _damage += cannon.Base.Ammo.Damage;
            _projectileSpeed += cannon.Base.Ammo.Speed;
        }
    }
}