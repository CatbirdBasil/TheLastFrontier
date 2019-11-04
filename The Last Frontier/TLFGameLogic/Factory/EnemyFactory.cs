namespace TLFGameLogic.Model
{
    public class EnemyFactory
    {
        public static Enemy CreateEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.SmallSlime:
                {
                    return new Enemy(
                        "Small slime",
                        20f,
                        2.5f,
                        1.0f,
                        1f,
                        enemyType);
                }
            }

            return null;
        }
    }
}