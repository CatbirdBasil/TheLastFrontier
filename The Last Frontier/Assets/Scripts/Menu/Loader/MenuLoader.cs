using Intents;
using Menu.Loader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuLoader : MonoBehaviour
{
    [Inject] private IntentResolver _intentResolver;
    [Inject] private InventorySceneLoader _inventory;
    [Inject] private LevelsSceneLoader _levels;
    [Inject] private StoreSceneLoader _store;

    public MenuSceneType SceneType = MenuSceneType.Inventory;

    private void OnEnable()
    {
        Debug.Log("LevelLoader enabled");
        SceneManager.sceneLoaded += LoadCurrentMenu;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LoadCurrentMenu;
    }

    private void LoadCurrentMenu(Scene scene, LoadSceneMode mode)
    {
        _intentResolver.Resolve();
        LoadScene(SceneType);
    }

    public void LoadScene(MenuSceneType sceneType)
    {
        SceneType = sceneType;

        switch (sceneType)
        {
            case MenuSceneType.Shop:
                _store.LoadScene();
                break;
            case MenuSceneType.Levels:
                _levels.LoadScene();
                break;
            case MenuSceneType.Inventory:
                _inventory.LoadScene();
                break;
        }
    }

    public void SetCanvasDisable()
    {
        switch (SceneType)
        {
            case MenuSceneType.Shop:
                SetEnable("Store_Canvas", false);
                break;
            case MenuSceneType.Levels:
                SetEnable("Levels_Canvas", false);
                break;
            case MenuSceneType.Inventory:
                SetEnable("Inventory_Canvas", false);
                break;
        }
    }

    public void SetEnable(string objects, bool enable)
    {
        var tempObject = GameObject.Find(objects);
        if (tempObject == null) return;
        var InventoryCanvas = tempObject.GetComponent<Canvas>();
        if (InventoryCanvas != null)
            InventoryCanvas.enabled = enable;
    }
}