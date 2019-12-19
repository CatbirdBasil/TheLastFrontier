using System;
using System.Collections;
using UnityEngine;

namespace Level.PopUps
{
    public class EndScreenMenuPresenter : MonoBehaviour
    {
        public GameObject PauseMenuUI;
        public GameObject VictoryScreenUI;
        public GameObject DefeatScreenUI;

        public static EndScreenMenuPresenter Instance;

        private void OnEnable()
        { 
            EndScreenMenuPresenter.Instance = this;
        } 

        void OnDisable()
        {
            EndScreenMenuPresenter.Instance = null;
        }
        
        public static void ShowVictoryScreen()
        {
            Instance.StartCoroutine(ShowScreen(Instance.VictoryScreenUI, 1.5f));
        }

        public static void ShowDefeatScreen()
        {
            Instance.StartCoroutine(ShowScreen(Instance.DefeatScreenUI, 0.5f));
        }
        
        private static IEnumerator ShowScreen(GameObject screen, float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            screen.SetActive(true);
            Instance.PauseMenuUI.SetActive(false);
            Time.timeScale = 0f; 
        }
    }
}