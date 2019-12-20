using System.Collections;
using Level.PopUps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : LevelMenu
{
    public void RetryLevel()
    {
        StartCoroutine(ReloadLevel());
    }

    private IEnumerator ReloadLevel()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}