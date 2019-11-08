using System;
using System.Collections.Generic;
using Level.DTO;
using Level.LevelEventArgs;
using TLFGameLogic;
using TLFGameLogic.Model.LevelData;
using TLFUILogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

//TODO Refactor
public class LevelLoader : ScriptableObject
{
    [Inject] private IEnemyFactory _enemyFactory;
    [Inject] private ILevelInfoProvider _levelInfoProvider;
    [Inject] private CurrentCannonLoadoutProvider _loadoutProvider;

    public event EventHandler LoadingCompleted = delegate { };
    public event EventHandler<CurrentCannonLoadoutEventArgs> CurrentCannonLoadoutLoadingCompleted = delegate { };
    public event EventHandler<LevelInfoEventArgs> LevelInfoLoadingCompleted = delegate { };
    public event EventHandler<SpawnPointEventArgs> SpawnPointsLoadingCompleted = delegate { };

    private void OnEnable()
    {
        Debug.Log("LevelLoader enabled");
        SceneManager.sceneLoaded += InstantiateLevelData;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= InstantiateLevelData;
    }

    private void InstantiateLevelData(Scene scene, LoadSceneMode mode)
    {
        var currentLevel = 1;

        LoadSpawnPoints();
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
        _enemyFactory.WarmUp(levelInfo.EstimatedMaxEnemiesOnScreen);

        LevelInfoLoadingCompleted(this, new LevelInfoEventArgs(levelInfo));
    }

    private void LoadSpawnPoints()
    {
        var spawnPointDtos = new List<SpawnPointDTO>(7);

        var spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        Array.Sort(spawnPoints, (x, y) => x.transform.up.y.CompareTo(y.transform.up.y));

        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[0].transform, SpawnPoint.A));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[1].transform, SpawnPoint.B));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[2].transform, SpawnPoint.C));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[3].transform, SpawnPoint.D));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[4].transform, SpawnPoint.E));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[5].transform, SpawnPoint.F));
        spawnPointDtos.Add(new SpawnPointDTO(spawnPoints[6].transform, SpawnPoint.G));

        SpawnPointsLoadingCompleted(this, new SpawnPointEventArgs(spawnPointDtos));
    }
}