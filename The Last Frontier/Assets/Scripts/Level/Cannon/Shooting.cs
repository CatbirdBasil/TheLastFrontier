using Level;
using Level.Cannon;
using UnityEngine;
using Zenject;

public class Shooting : MonoBehaviour
{
    [Inject] private IBulletFactory _bulletFactory;
    [Inject] private PlayerState _playerState;

    public Transform firePoint;
    public float timeBeforeNextShot;

    //todo update logic to shoot instantly
    private void Update()
    {
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