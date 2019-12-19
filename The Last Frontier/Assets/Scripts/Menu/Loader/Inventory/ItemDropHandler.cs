using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu.Loader.Inventory
{
    public class ItemDropHandler :MonoBehaviour,IDropHandler
    {
        
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("!!!");
            RectTransform invPanel = transform as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
            {
                Debug.Log("New Base!!!");
            }
        }
    }
}