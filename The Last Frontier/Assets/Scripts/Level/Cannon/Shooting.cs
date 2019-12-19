using Level;
using Level.Cannon;
using TLFGameLogic.Model;
using TLFGameLogic.Model.CannonData.Barrel;
using TLFUILogic;
using UnityEngine;
using Zenject;

public class Shooting : MonoBehaviour
{
    private const string ShootTrigger = "Shoot";
    private Animator _animator;
    [Inject] private IBulletFactory _bulletFactory;
    [Inject] private PlayerState _playerState;

    public Transform firePoint;
    private float timeBeforeNextShot = 0.2f;

    private Animator GetShotAnimator()
    {
        if (_animator == null)
        {
            _animator = GetComponentInChildren<Animator>();
        }

        return _animator;
    }

    [Inject] private CannonPartFactory _cannonPartFactory;

    private void Update()
    {
        if (Input.touchCount != 0 || Input.GetButton("Fire1"))
        {
            if (!DetectionUtils.IsOnPauseButton(DetectionUtils.GetOnScreenInputPosition()))
            {
                if (timeBeforeNextShot <= 0)
                {
                    //TODO REMOVEEE
                    /*CannonPart part = _cannonPartFactory.GetCommonBoxPart();
                    if (part is CannonBase)
                    {
                        CannonBase cannonBase = part as CannonBase;
                        Debug.Log("CannonBase: Name = [" + cannonBase.Name + "], Dmg = [" + cannonBase.Damage +
                                  "], AS = [" + cannonBase.AttackSpeed + "], PS = [" + cannonBase.ProjectileSpeed +
                                  "], Rang = [" + cannonBase.Rang + "]");
                    }
                    else if (part is Barrel)
                    {
                        Barrel barrel = part as Barrel;
                        Debug.Log("Barrel: Name = [" + barrel.Name + "], DmgMult = [" + barrel.DamageMultiplier +
                                  "], ASMult = [" + barrel.AttackSpeedMultiplier + "], Addit = [" + barrel.AdditionalShotsAmount +
                                  "], Rang = [" + barrel.Rang + "]");
                    }*/

                    Shoot();
                    GetShotAnimator().SetTrigger(ShootTrigger);
                    timeBeforeNextShot = 1f / _playerState.CurrentCannonLoadout.AttackSpeed;
                    Debug.Log(_playerState.CurrentBase);
                }
                else
                {
                    timeBeforeNextShot -= Time.deltaTime;
                }
            }
        }
        else
        {
            if (timeBeforeNextShot >= 0.1f) timeBeforeNextShot -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        var bullet = _bulletFactory.GetBullet();
        bullet.gameObject.transform.position = firePoint.position;
        bullet.gameObject.transform.rotation = firePoint.rotation;
        bullet.RigidBody.AddForce(firePoint.right * bullet.Speed, ForceMode2D.Impulse);
    }
}