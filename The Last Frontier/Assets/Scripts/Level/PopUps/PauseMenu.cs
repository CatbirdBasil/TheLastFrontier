using System.Collections;
using Level.PopUps;
using UnityEngine;

public class PauseMenu : LevelMenu
{
    private static bool _hasPendingPause;
    public GameObject PauseButtonUI;
    public GameObject PauseMenuUI;
    public static bool GameIsPaused { get; private set; }

    public void RequestPause()
    {
        Debug.Log("Pause requested");
        _hasPendingPause = true;
    }

    private void Update()
    {
        if (_hasPendingPause)
        {
            if (GameIsPaused)
                StartCoroutine(ResumeWithDelay());
            else
                Pause();

            _hasPendingPause = false;
        }
    }

    private void Resume()
    {
        PauseButtonUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private IEnumerator ResumeWithDelay()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Resume();
    }

    private void Pause()
    {
        PauseButtonUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private new void OpenMenu()
    {
        Resume();
        base.OpenMenu();
    }
}