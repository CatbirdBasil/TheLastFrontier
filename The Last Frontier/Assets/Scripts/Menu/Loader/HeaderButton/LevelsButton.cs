using UnityEngine;
using Zenject;

namespace Menu.Loader
{
    public class LevelsButton:MonoBehaviour
    {
        [Inject] private MenuLoader _menuLoader;
    
        public void LevelsButtonClick()
        {
            if (_menuLoader.SceneType != MenuSceneType.Levels)
            {    _menuLoader.SetCanvasDisable();
                _menuLoader.LoadScene(MenuSceneType.Levels);
            }
        }
    }
}