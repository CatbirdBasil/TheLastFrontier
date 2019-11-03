namespace TLFGameLogic.Model
{
    public class Ammo
    {
        public float Damage { get; }
        public float Speed { get; }

        public Ammo()
        {
            Damage = 1f;
            Speed = 10f;
        }
    }
}