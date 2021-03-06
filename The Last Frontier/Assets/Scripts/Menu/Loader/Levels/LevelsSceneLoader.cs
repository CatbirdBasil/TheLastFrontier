using UnityEngine;

namespace Menu.Loader
{
    public class LevelsSceneLoader:MenuSceenLoader
    {
        public Canvas LevelCanvas { get; set; }
        public void LoadScene()
        {
            GameObject tempObject = GameObject.Find("Levels_Canvas");
            if (tempObject == null) return;
            LevelCanvas = tempObject.GetComponent<Canvas>();
            if (LevelCanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
            else
            {
                LevelCanvas.enabled = true;
            }
        }
    }
}