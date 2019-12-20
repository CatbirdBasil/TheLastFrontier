using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu.Loader
{
    public class LevelButton:MonoBehaviour
    {
        public Button Item;
        public TextMeshProUGUI LevelText;
        private int _level;
        private Color normalColor;
        private bool notNirmalColor=false;
        
    
        void Start()
        {
            LevelText.text = _level.ToString();
        }
        public void SetUp(int Level)
        {
            _level = Level;
        }
    
        public void HandleClick()
        {
            //Todo start level
            Debug.Log(_level);
        }
    }
}