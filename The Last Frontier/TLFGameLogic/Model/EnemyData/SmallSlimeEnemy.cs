namespace TLFGameLogic.Model
{
    public class SmallSlimeEnemy : Enemy
    {
        public SmallSlimeEnemy()
        {
            Name = "Small slime";
            Health = 20f;
            Damage = 2.5f;
            AttackSpeed = 1.0f;
            Speed = 1f;
        }
    }
}