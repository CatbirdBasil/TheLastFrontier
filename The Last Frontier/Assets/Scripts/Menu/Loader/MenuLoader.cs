using System;
using System.Collections;
using System.Collections.Generic;
using Menu.Loader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuLoader : ScriptableObject
{
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
        switch (SceneType)
        {
            case MenuSceneType.Store:
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
    
}
