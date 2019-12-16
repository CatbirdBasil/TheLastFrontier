namespace TLFGameLogic.Model.CannonData.Config
{
    public class CannonConfig
    {
        public class CannonBase
        {
            // ----- CannonBase Part START -------------------
            public const float BasicValueCommon = 15f;

            public const float DamageMinCommon = 3f;
            public const float DamageMaxCommon = 6f;

            public const float AttackSpeedMinCommon = 0.8f;
            public const float AttackSpeedMaxCommon = 1.1f;

            public const float ProjectileSpeedMinCommon = 9f;
            public const float ProjectileSpeedMaxCommon = 13f;

            public const float DamageValueMultiplier = 1f;
            public const float AttackSpeedValueMultiplier = 5f;

            public const float ProjectileSpeedValueMultiplier = 0.1f;
            // ----- CannonBase Part END ---------------------
        }

        public class Barrel
        {
            // ----- Barrel Part START -------------------
            public const float BasicValueCommon = 8f;

            public const float DamageMultiplierMinCommon = -0.2f;
            public const float DamageMultiplierMaxCommon = -0.05f;

            public const float AttackSpeedMultiplierMinCommon = 1.07f;
            public const float AttackSpeedMultiplierMaxCommon = 1.2f;

            public const float DamageMultiplierValueMultiplier = 0.5f;
            public const float AttackSpeedMultiplierValueMultiplier = 2f;

            public const float AdditionalProjectilesValueMultiplier = 6f;
            // ----- Barrel Part END ---------------------
        }
    }
}