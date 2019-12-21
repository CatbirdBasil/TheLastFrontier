using System;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFUILogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Menu.Loader
{
    public class ShopMenu : MonoBehaviour
    {
        public TextMeshProUGUI money;

        [Inject] private CannonPartFactory _cannonPartFactory;
        private PlayerData _playerData;

        private void OnEnable()
        {
            _playerData = PlayerData.Instance;
            money.text = _playerData.Money.ToString();
        }

        public void GetPart()
        {
            if (_playerData.Money >= 250)
            {
                _playerData.Money -= 250;

                CannonPart part = _cannonPartFactory.GetCommonBoxPart();

                if (part is CannonBase)
                {
                    CannonBase cannonBase = part as CannonBase;
                    Debug.Log("CannonBase: Name = [" + cannonBase.Name + "], Dmg = [" + cannonBase.Damage +
                              "], AS = [" + cannonBase.AttackSpeed + "], PS = [" + cannonBase.ProjectileSpeed +
                              "], Rang = [" + cannonBase.Rang + "]");
                }
                else if (part is Barrel)
                {
                    Barrel barrel = part as Barrel;
                    Debug.Log("Barrel: Name = [" + barrel.Name + "], DmgMult = [" + barrel.DamageMultiplier +
                              "], ASMult = [" + barrel.AttackSpeedMultiplier + "], Addit = [" +
                              barrel.AdditionalShotsAmount +
                              "], Rang = [" + barrel.Rang + "]");
                }

                if (part is CannonBase)
                {
                    _playerData.BaseCannonFragments.Add(part as CannonBase);
                }
                else if (part is Barrel)
                {
                    _playerData.Barrels.Add(part as Barrel);
                }

                money.text = _playerData.Money.ToString();
            }
        }
    }
}