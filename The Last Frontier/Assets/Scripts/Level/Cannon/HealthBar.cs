using Level;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [Inject] private PlayerState _playerState;
    private float CurrHealth;
    public Image heathBar;

    private float maxHealth;

    //public  heathBar;
    private float mCurrentValue;
    private int minHealth = 0;

    private void Start()
    {
        maxHealth = _playerState.CurrentBase.MaxHp;
    }

    private void SetHeath(float heath)
    {
        if (CurrHealth != heath)
        {
            CurrHealth = heath;
            mCurrentValue = heath / maxHealth;
            heathBar.fillAmount = mCurrentValue;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_playerState.CurrentBase != null) SetHeath(_playerState.CurrentBase.CurrentHp);
    }
}