using Menu.Loader.Inventory;
using TLFGameLogic.Model.CannonData.Enum;
using UnityEngine;
using UnityEngine.UIElements;

namespace Menu.Loader
{
    public class InventorySceneLoader : MenuSceenLoader
    {
        public Canvas InventoryCanvas { get; set; }
        ItemPicturesResolver _resolver = new ItemPicturesResolver();
        public ScrollView ItemsList { get; set; }


        public void LoadScene()
        {
            GameObject tempObject = GameObject.Find("Inventory_Canvas");
            if (tempObject == null) return;
            InventoryCanvas = tempObject.GetComponent<Canvas>();
            if (InventoryCanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
            else
            {
                InventoryCanvas.enabled = true;
                
            }
        }
    }
}