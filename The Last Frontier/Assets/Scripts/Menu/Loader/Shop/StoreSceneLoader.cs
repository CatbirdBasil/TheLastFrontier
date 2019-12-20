using UnityEngine;

namespace Menu.Loader
{
    public class StoreSceneLoader : MenuSceenLoader
    {
        public Canvas ShopCanvas { get; set; }

        public void LoadScene()
        {
            GameObject tempObject = GameObject.Find("Shop_Canvas");
            if (tempObject == null) return;
            ShopCanvas = tempObject.GetComponent<Canvas>();
            if (ShopCanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
            else
            {
                ShopCanvas.enabled = true;
            }
        }
    }
}