using System;
using Menu.Loader.Inventory;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemButton : MonoBehaviour
{
    //[Inject]  ItemPicturesResolver _resolver;
    private ItemPicturesResolver _resolver;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI inventoryName;
    public Button Item;
    public Image ItemImage;
    public CannonBase _cannonBase { get; private set; }
    public Barrel _barrel{ get; private set; }
    private ItemDragHendler _dragHendler;
    
    void Start()
    {
        
        _dragHendler =gameObject.AddComponent<ItemDragHendler>(); 
        _dragHendler.ItemButton = this;
        Item.onClick.AddListener (HandleClick);
    }

    public void SetUp(CannonBase cannonBase,Barrel barrel,TextMeshProUGUI name,TextMeshProUGUI text,ItemPicturesResolver resolver)
    {
        _cannonBase = cannonBase;
        _barrel = barrel;
        inventoryName = name;
        inventoryText = text;
        _resolver = resolver;
    }

    public void SetPicture()
    {
        Debug.Log(_barrel);
        if (_barrel != null)
        {
            ItemImage.color = Color.white;
            ItemImage.sprite = _resolver.GetBarrelImage(_barrel.BarrelType);
        }
        else if (_cannonBase != null && _resolver.GetBaseImage(_cannonBase.CannonBaseType) != null)
        {
           // Debug.Log(_cannonBase.CannonBaseType);
            ItemImage.sprite = _resolver.GetBaseImage(_cannonBase.CannonBaseType);
        }
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
            inventoryName.text = "Cannon Barrel";
            inventoryText.text = GetBarrelInto(_barrel);
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

    public String GetBarrelInto(Barrel _barrel)
    {
        String type = "Regular barrel";
        String damageMultiplier = _barrel.DamageMultiplier.ToString();
        String speed = this._barrel.AttackSpeedMultiplier.ToString();
        int shoot = _barrel.AdditionalShotsAmount;
        return "Type: " + type + "\n" 
               + "Damage multiplier: " + damageMultiplier + "\n" 
               + "Attack Speed Multiplier: " + speed + "\n" +
               "Shots Amount: " + (shoot+ 1).ToString();
    }



}
