using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingAnimator : MonoBehaviour
{
    [Inject] private LevelLoader _levelLoader;

    private void Start()
    {
        Debug.Log("Animation active");
    }

    private void OnEnable()
    {
        _levelLoader.LoadingCompleted += OnLevelLoaded;
    }

    private void OnDisable()
    {
        _levelLoader.LoadingCompleted -= OnLevelLoaded;
    }

    private void OnLevelLoaded(object sender, EventArgs args)
    {
        Debug.Log("Animation end");
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        transform.gameObject.SetActive(false);
    }

    public void StartForTransition()
    {
        transform.gameObject.SetActive(true);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.4f);
    }
}