using System.Collections.Generic;
using TLFGameLogic.Model;
using TLFGameLogic.Model.BaseData;
using TLFGameLogic.Model.CannonData.Barrel;

namespace TLFUILogic
{
    public class PlayerDataForSafe
    {
        public int[] Level;
        
        public int Money;
        public int SpecialMoney;

        public int currentBase;
        public int currentBarrel;
        
        //Cannon Base characteristics 
        public int[] Rangs;
        public float[] Damages;
        public float[] AttackSpeeds;
        public int[] ProjectileTypes;
        public float[] ProjectsSpeed;
        public int[] CannonBaseTypes;

        //Barrel characteristics 
        public float[] DamageMultipliers;
        public float[] AttackSpeedMultipliers;
        public int[] BarrelTypes;
        public int[] BarrelModels;
        public int[] AdditionalShotsAmounts;


        public PlayerDataForSafe(PlayerData playerData)
        {
            Money = playerData.Money;
            SpecialMoney = playerData.SpecialMoney;

            InitializeBaseForSafe(playerData.BaseCannonFragments);
            IitializeBarrelForSafe(playerData.Barrels);
            
            Level = new int[playerData.Level.Count];
            for (var i = 0; i < playerData.Level.Count; i++) Level[i] = playerData.Level[i];
            
        }

        public void InitializeBaseForSafe(List<CannonBase> bases)
        {
            int size = bases.Count;

            Rangs = new int[size];
            Damages = new float[size];
            AttackSpeeds = new float[size];
            ProjectileTypes = new int[size];
            ProjectsSpeed = new float[size];
            CannonBaseTypes = new int[size];
            for (int i = 0; i < size; i++)
            {
                Rangs[i] = (int) bases[i].Rang;
                Damages[i] = bases[i].Damage;
                AttackSpeeds[i] = bases[i].AttackSpeed;
                ProjectileTypes[i] = (int) bases[i].ProjectileType;
                ProjectsSpeed[i] = bases[i].ProjectileSpeed;
                CannonBaseTypes[i] = (int) bases[i].CannonBaseType;
            }
        }

        public void IitializeBarrelForSafe(List<Barrel> barrels)
        {
            int size = barrels.Count;
            DamageMultipliers = new float[size];
            AttackSpeedMultipliers = new float[size];
            BarrelTypes = new int[size];
            BarrelModels = new int[size];
            AdditionalShotsAmounts = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                DamageMultipliers[i] = barrels[i].DamageMultiplier;
                AttackSpeeds[i] = barrels[i].AttackSpeedMultiplier;
                BarrelTypes[i] = (int) barrels[i].BarrelType;
                BarrelModels[i] = (int) barrels[i].BarrelModel;
                AdditionalShotsAmounts[i] = barrels[i].AdditionalShotsAmount;
            }
        }
    }
}