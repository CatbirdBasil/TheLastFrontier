using System.Collections;
using System.Collections.Generic;
using Level.PopUps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : EndScreenMenu
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
