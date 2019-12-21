using System.Drawing;
using ModestTree;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu.Loader.Inventory
{
    public class ItemDropHandler :MonoBehaviour,IDropHandler
    {
        public Image Base;
        public Image Barrel;
        public ItemButton ItemButton;
        public void OnDrop(PointerEventData eventData)
        {
            RectTransform invPanel = transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
            {
                
                Debug.Log(invPanel);
               // Debug.Log(invPanel.GetComponent<Image>());
               // Image Barrel = GameObject.Find("Barrel_Image").GetComponent<Image>();
               // Image Base = GameObject.Find("Base_Image").GetComponent<Image>();
               // Debug.Log(ItemButton);

            }
        }
    }
}