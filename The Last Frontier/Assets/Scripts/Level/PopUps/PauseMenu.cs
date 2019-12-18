using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused { get; private set; }
    public GameObject PauseMenuUI;
    public GameObject PauseButtonUI;

    private static bool _hasPendingPause;
    
    public void RequestPause()
    {
        Debug.Log("Pause requested");
        _hasPendingPause = true;
    }
    
    void Update()
    {
        if (_hasPendingPause)
        {
            if (GameIsPaused)
            {
                StartCoroutine(ResumeWithDelay());
            }
            else
            {
                Pause();
            }

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
}
