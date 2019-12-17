using System.Collections.Generic;
using TLFGameLogic.Model.CannonData.Enum;
using TLFUILogic;

namespace TLFGameLogic.Model.CannonData.CannonBase
{
    // Maybe extract interface
    public class CannonBaseModelHelper
    {
        private static readonly Dictionary<CannonBaseModel, string> _cannonBaseNames;
        private static readonly Dictionary<CannonBaseModel, CannonBaseType> _cannonBaseTypes;
        private static readonly Dictionary<CannonBaseModel, ProjectileType> _cannonBaseProjectileTypes;
        private static readonly string NameNotFound = "Undefined";

        static CannonBaseModelHelper()
        {
            _cannonBaseNames = new Dictionary<CannonBaseModel, string>
            {
                {CannonBaseModel.SimpleRegularGun, "Simple Cannon"}
            };

            _cannonBaseTypes = new Dictionary<CannonBaseModel, CannonBaseType>
            {
                {CannonBaseModel.SimpleRegularGun, CannonBaseType.RegularGun}
            };

            _cannonBaseProjectileTypes = new Dictionary<CannonBaseModel, ProjectileType>
            {
                {CannonBaseModel.SimpleRegularGun, ProjectileType.Bullet}
            };
        }

        public static string GetName(CannonBaseModel model)
        {
            var name = _cannonBaseNames[model];

            return name == null ? NameNotFound : name;
        }

        public static CannonBaseType GetType(CannonBaseModel model)
        {
            var type = _cannonBaseTypes[model];

            return type;
        }

        public static ProjectileType GetProjectileType(CannonBaseModel model)
        {
            var type = _cannonBaseProjectileTypes[model];

            return type;
        }
    }
}