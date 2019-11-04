using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

using TLFGameLogic;
using TLFGameLogic.Model;
using TLFUILogic;
using Zenject;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Inject]
    private CurrentCannonLoadoutProvider loadoutProvider;
    
    [Inject]
    private ILevelInfoProvider levelInfoProvider;
    
    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    } 

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        //CurrentCannonLoadout loadout = loadoutProvider.GetLoadout();
        //Debug.Log("Damage = " + loadout.Damage);

        LevelInfo levelInfo = levelInfoProvider.GetLevel(1);
        Debug.Log("LevelInfo = " + levelInfo.EnemiesSpawnInfo[0].Enemy.Name);
        Enemy enemy = levelInfo.EnemiesSpawnInfo[0].Enemy;
        
        levelInfo.AllEnemiesDead += delegate(object sender, EventArgs args) { Debug.Log("ALL DEAD"); };
        
        Debug.Log("HP = " + enemy.Health);
        enemy.TakeDamage(10f);
        Debug.Log("HP = " + enemy.Health);
        enemy.TakeDamage(51f);
        Debug.Log("HP = " + enemy.Health);



    }
}
