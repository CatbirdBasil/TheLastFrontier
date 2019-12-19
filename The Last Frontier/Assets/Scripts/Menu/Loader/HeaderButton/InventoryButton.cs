using System.Diagnostics;
using UnityEngine;
using Zenject;

namespace Menu.Loader
{
    public class InventoryButton:MonoBehaviour
    {
        [Inject] private MenuLoader _menuLoader;
    
        public void InventoryButtonClick()
        {
            if (_menuLoader.SceneType != MenuSceneType.Inventory)
            {    _menuLoader.SetCanvasDisable();
                _menuLoader.LoadScene(MenuSceneType.Inventory);
            }
        }
    }
}