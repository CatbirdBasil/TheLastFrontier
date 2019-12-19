using System.Collections;
using System.Collections.Generic;
using Menu.Loader;
using UnityEngine;
using Zenject;

public class ShopButtons : MonoBehaviour
{
    [Inject] private MenuLoader _menuLoader;
    
    public void ShopButton()
    {
        Debug.Log("It alive");
        if (_menuLoader.SceneType != MenuSceneType.Shop)
        {    _menuLoader.SetCanvasDisable();
            _menuLoader.LoadScene(MenuSceneType.Shop);
        }
    }
}
