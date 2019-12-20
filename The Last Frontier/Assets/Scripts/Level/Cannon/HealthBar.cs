using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private int minHealth = 0;
    private float CurrHealth;
    public Image heathBar;
    //public  heathBar;
    private float mCurrentValue;
    [Inject] private PlayerState _playerState;
    
    void Start()
    {
        maxHealth = _playerState.CurrentBase.MaxHp;
    }

    private void SetHeath(float heath)
    {
        if (CurrHealth != heath)
        {
            CurrHealth = heath;
            mCurrentValue =  heath / maxHealth;
            heathBar.fillAmount = mCurrentValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetHeath(_playerState.CurrentBase.CurrentHp);
    }
}
