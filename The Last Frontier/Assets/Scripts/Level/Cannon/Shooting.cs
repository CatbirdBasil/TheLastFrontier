using Level;
using Level.Cannon;
using Level.Model.Cannon;
using TLFGameLogic;
using TLFUILogic;
using UnityEngine;
using Zenject;
using Random = System.Random;

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
            } else if (Input.GetButton("Fire1"))
            {
                Shoot();
            }

            timeBeforeNextShot = 1f / _playerState.CurrentCannonLoadout.AttackSpeed;
        }
        else
        {
            timeBeforeNextShot -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        BulletViewModel bullet = _bulletFactory.GetBullet();
        bullet.gameObject.transform.position = firePoint.position;
        bullet.gameObject.transform.rotation = firePoint.rotation;
        bullet.RigidBody.AddForce(firePoint.right * bullet.Speed, ForceMode2D.Impulse);
    }
}