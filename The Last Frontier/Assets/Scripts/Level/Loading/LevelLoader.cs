using System;
using Level.LevelEventArgs;
using TLFGameLogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader : MonoBehaviour
{
    [Inject] private ILevelInfoProvider _levelInfoProvider;

    [Inject] private CurrentCannonLoadoutProvider _loadoutProvider;

    public event EventHandler LoadingCompleted = delegate { };
    public event EventHandler<CurrentCannonLoadoutEventArgs> CurrentCannonLoadoutLoadingCompleted = delegate { };
    public event EventHandler<LevelInfoEventArgs> LevelInfoLoadingCompleted = delegate { };

    private void OnEnable()
    {
        SceneManager.sceneLoaded += InstantiateLevelData;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= InstantiateLevelData;
    }

    private void InstantiateLevelData(Scene scene, LoadSceneMode mode)
    {
        var currentLevel = 1;

        LoadCurrentCannonLoadout();
        LoadLevelInfo(currentLevel);
        LoadingCompleted(this, EventArgs.Empty);
    }

    private void LoadCurrentCannonLoadout()
    {
        var currentCannonLoadout = _loadoutProvider.GetLoadout();

        // Cannon prefab and etc instantiation logic

        CurrentCannonLoadoutLoadingCompleted(this, new CurrentCannonLoadoutEventArgs(currentCannonLoadout));
    }

    private void LoadLevelInfo(int level)
    {
        var levelInfo = _levelInfoProvider.GetLevel(level);

        // Enemies and etc instantiation logic

        LevelInfoLoadingCompleted(this, new LevelInfoEventArgs(levelInfo));
    }
}