using TLFGameLogic.Model;

namespace TLFGameLogic
{
    // TODO Refacator to use Builder
    public class CurrentCannonLoadout
    {
        //public float DamagePerHit { get; private set; }

        public CurrentCannonLoadout(float damage, float attackSpeed, ProjectileType projectileType,
            float projectileSpeed, int amountOfAdditionalShots, Cannon cannon)
        {
            Damage = damage;
            AttackSpeed = attackSpeed;
            ProjectileType = projectileType;
            ProjectileSpeed = projectileSpeed;
            AmountOfAdditionalShots = amountOfAdditionalShots;
            Cannon = cannon;
        }

        public float Damage { get; }
        public float AttackSpeed { get; }
        public ProjectileType ProjectileType { get; }
        public float ProjectileSpeed { get; }
        public int AmountOfAdditionalShots { get; }
        public Cannon Cannon { get; }
    }
}