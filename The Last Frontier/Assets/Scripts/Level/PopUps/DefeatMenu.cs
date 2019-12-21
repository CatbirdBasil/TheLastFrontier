using System.Collections;
using Level;
using Level.PopUps;
using TLFUILogic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class DefeatMenu : LevelMenu
{
    public Text MoneyText;
    [Inject] private LevelStateManager _levelStateManager;
    
    public void RetryLevel()
    {
        StartCoroutine(ReloadLevel());
    }

    private void OnEnable()
    {
        int money = _levelStateManager.LevelInfo.Reward / 10;
        MoneyText.text = money.ToString();
        PlayerData.Instance.Money += money;
        //var _player = _file.getInfo();
        // _player.Level.Add(_levelInfo.LevelNumber);
        //_file.saveInfo(_player);
        //_levelLoader.LevelInfoLoadingCompleted += OnLevelInfoLoadingCompleted;
    }
    
    private IEnumerator ReloadLevel()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}