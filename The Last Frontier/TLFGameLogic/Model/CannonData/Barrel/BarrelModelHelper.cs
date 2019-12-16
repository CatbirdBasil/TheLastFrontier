using System.Collections.Generic;
using TLFGameLogic.Model.CannonData.Enum;
using TLFGameLogic.Model.CannonData.Enum.Barrel;

namespace TLFGameLogic.Model.CannonData.Barrel
{
    public class BarrelModelHelper
    {
        private static readonly Dictionary<BarrelModel, string> _barrelNames;
        private static readonly Dictionary<BarrelModel, BarrelType> _barrelTypes;
        private static readonly string NameNotFound = "Undefined";

        static BarrelModelHelper()
        {
            _barrelNames = new Dictionary<BarrelModel, string>
            {
                {BarrelModel.SimpleBarrel, "Simple Barrel"}
            };

            _barrelTypes = new Dictionary<BarrelModel, BarrelType>
            {
                {BarrelModel.SimpleBarrel, BarrelType.Simple}
            };
        }

        public static string GetName(BarrelModel model)
        {
            var name = _barrelNames[model];

            return name == null ? NameNotFound : name;
        }

        public static BarrelType GetType(BarrelModel model)
        {
            var type = _barrelTypes[model];

            return type;
        }
    }
}