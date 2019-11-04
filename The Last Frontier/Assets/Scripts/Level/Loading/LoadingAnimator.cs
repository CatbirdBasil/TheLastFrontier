using System;
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
        transform.gameObject.SetActive(false);
    }
}