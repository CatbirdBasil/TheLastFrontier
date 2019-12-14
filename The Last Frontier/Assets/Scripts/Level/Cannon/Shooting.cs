using Level;
using Level.Cannon;
using UnityEngine;
using Zenject;

public class Shooting : MonoBehaviour
{
    [Inject] private IBulletFactory _bulletFactory;
    [Inject] private PlayerState _playerState;

    public Transform firePoint;
    private float timeBeforeNextShot = 0.2f;

    //todo update logic to shoot instantly
    private void Update()
    {
        if (Input.touchCount != 0 || Input.GetButton("Fire1"))
        {
            if (timeBeforeNextShot <= 0)
            {
                Shoot();
                timeBeforeNextShot = 1f / _playerState.CurrentCannonLoadout.AttackSpeed;
            }
            else
            {
                timeBeforeNextShot -= Time.deltaTime;
            }
        }
        else
        {
            if (timeBeforeNextShot >= 0.1f)
            {
                timeBeforeNextShot -= Time.deltaTime;
            }
        }
        
        /*
        if (timeBeforeNextShot <= 0)
        {
            if (Input.touchCount != 0)
            {
                Shoot();
                timeBeforeNextShot = 1f / _playerState.CurrentCannonLoadout.AttackSpeed;
            }
            else if (Input.GetButton("Fire1"))
            {
                Shoot();
                timeBeforeNextShot = 1f / _playerState.CurrentCannonLoadout.AttackSpeed;
            }
        }
        else
        {
            timeBeforeNextShot -= Time.deltaTime;
        }*/
    }

    private void Shoot()
    {
        var bullet = _bulletFactory.GetBullet();
        bullet.gameObject.transform.position = firePoint.position;
        bullet.gameObject.transform.rotation = firePoint.rotation;
        bullet.RigidBody.AddForce(firePoint.right * bullet.Speed, ForceMode2D.Impulse);
    }
}