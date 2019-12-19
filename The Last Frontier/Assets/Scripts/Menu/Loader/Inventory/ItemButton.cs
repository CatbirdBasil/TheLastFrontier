using System;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI inventoryName;
    public Button Item;
    public Image ItemImage;
    private CannonBase _cannonBase;
    private Barrel _barrel;
    
    void Start()
    {
        Item.onClick.AddListener (HandleClick);
    }

    public void SetUp(CannonBase cannonBase,Barrel barrel,TextMeshProUGUI name,TextMeshProUGUI text)
    {
        _cannonBase = cannonBase;
        _barrel = barrel;
        inventoryName = name;
        inventoryText = text;
    }
    
    public void HandleClick()
    {
        Debug.Log(_cannonBase);
        
        if (_cannonBase != null)
        {
            inventoryName.text = "Cannon Base";
            inventoryText.text = GetCannonBaseInfo(_cannonBase);
        }
        else if (_barrel != null)
        {
            //TODO set strings
        }

    }

    public String GetCannonBaseInfo(CannonBase _cannonBase)
    {
        String type = "Regular Gun";
        String projectileType = _cannonBase.ProjectileType.ToString();
        String damage = _cannonBase.Damage.ToString();
        String attack= _cannonBase.AttackSpeed.ToString();
        return "Type: " + type + "\n" 
               + "Projectile Type: " + projectileType + "\n" 
               + "Damage: " + damage + "\n" +
               "Attack Speed: " + attack;
    }

//    public String GetBarrelInto(Barrel _barrel)
//    {
//        
//    }



}
