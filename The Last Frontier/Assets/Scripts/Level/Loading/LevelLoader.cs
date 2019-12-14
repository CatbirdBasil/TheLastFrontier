using System;
using System.Collections.Generic;
using Level.Cannon;
using Level.Cannon.Barrel;
using Level.Cannon.Base;
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
    [Inject] private BarrelAnimatorControllerResolver _barrelAnimatorControllerResolver;

    [Inject] private BarrelSpriteResolver _barrelSpriteResolver;
    [Inject] private IBaseProvider _baseProvider;
    [Inject] private IBulletFactory _bulletFactory;
    [Inject] private CannonBaseSpriteResolver _cannonBaseSpriteResolver;
    [Inject] private IEnemyFactory _enemyFactory;
    [Inject] private ILevelInfoProvider _levelInfoProvider;
    [Inject] private CurrentCannonLoadoutProvider _loadoutProvider;

    public event EventHandler LoadingCompleted = delegate { };
    public event EventHandler<CurrentCannonLoadoutEventArgs> CurrentCannonLoadoutLoadingCompleted = delegate { };
    public event EventHandler<BarrelEventArgs> BarrelLoadingCompleted = delegate { };
    public event EventHandler<CannonBaseEventArgs> CannonBaseLoadingCompleted = delegate { };
    public event EventHandler<BaseEventArgs> BaseLoadingCompleted = delegate { };
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
        LoadBase();
        LoadCurrentCannonLoadout();
        LoadLevelInfo(currentLevel);
        LoadingCompleted(this, EventArgs.Empty);
    }

    private void LoadBase()
    {
        var currentBase = _baseProvider.GetBase();

        // Base prefab and etc instantiation logic

        BaseLoadingCompleted(this, new BaseEventArgs(currentBase));
    }

    private void LoadCurrentCannonLoadout()
    {
        var currentCannonLoadout = _loadoutProvider.GetLoadout();
        _bulletFactory.WarmUp();
        CurrentCannonLoadoutLoadingCompleted(this, new CurrentCannonLoadoutEventArgs(currentCannonLoadout));

        var barrelSprite = _barrelSpriteResolver.GetBarrelSprite(currentCannonLoadout.Cannon.Barrel.BarrelModel);
        var barrelAnimatorController =
            _barrelAnimatorControllerResolver.GetAnimatorController(currentCannonLoadout.Cannon.Barrel.BarrelModel);
        BarrelLoadingCompleted(this, new BarrelEventArgs(barrelSprite, barrelAnimatorController));

        var cannonBaseSprite =
            _cannonBaseSpriteResolver.GetCannonBaseSprite(currentCannonLoadout.Cannon.Base.CannonBaseModel);
        CannonBaseLoadingCompleted(this, new CannonBaseEventArgs(cannonBaseSprite));
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