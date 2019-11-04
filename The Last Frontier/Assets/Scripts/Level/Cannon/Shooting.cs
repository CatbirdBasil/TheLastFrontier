using TLFGameLogic;
using TLFUILogic;
using UnityEngine;
using Zenject;
using Random = System.Random;

public class Shooting : MonoBehaviour
{
    [Inject] private IEnemyFactory _enemyFactory;

    public float bulletForce = 20f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Inject] private ILevelInfoProvider levelInfoProvider;

    [Inject] private CurrentCannonLoadoutProvider loadoutProvider;

    public Transform SpawnPoint;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Bullet prefab name = " + bulletPrefab.name);
            var enemy = levelInfoProvider.GetLevel(1).EnemiesSpawnInfo[0].Enemy;
            var random = new Random();
            SpawnPoint.position = new Vector3(13, 0, random.Next(-5, 5));
            _enemyFactory.GetEnemy(enemy, SpawnPoint);
            //levelInfoProvider.GetLevel(1).EnemiesSpawnInfo[0].SpawnPoint
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        //CurrentCannonLoadout loadout = loadoutProvider.GetLoadout();
        //Debug.Log("Damage = " + loadout.Damage);

        var levelInfo = levelInfoProvider.GetLevel(1);
        Debug.Log("LevelInfo = " + levelInfo.EnemiesSpawnInfo[0].Enemy.Name);
        var enemy = levelInfo.EnemiesSpawnInfo[0].Enemy;

        levelInfo.AllEnemiesDead += delegate { Debug.Log("ALL DEAD"); };

        Debug.Log("HP = " + enemy.Health);
        enemy.TakeDamage(10f);
        Debug.Log("HP = " + enemy.Health);
        enemy.TakeDamage(51f);
        Debug.Log("HP = " + enemy.Health);
    }
}