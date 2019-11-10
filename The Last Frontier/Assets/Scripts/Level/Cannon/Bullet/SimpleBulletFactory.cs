using System;
using System.Collections.Generic;
using Level.Model.Cannon;
using UnityEngine;
using Zenject;

namespace Level.Cannon
{
    public class SimpleBulletFactory : ScriptableObject, IBulletFactory
    {
        [Inject] private BulletPrefabResolver _bulletPrefabResolver;
        [Inject] private PlayerState _playerState;

        public void WarmUp()
        {
        }

        public BulletViewModel GetBullet()
        {
            //TODO Refactor
            var prefab = _bulletPrefabResolver.GetBulletPrefab(_playerState.CurrentCannonLoadout.Cannon.Base.CannonBaseType);
            var bulletGameObject = Instantiate(prefab);
            //bulletGameObject.SetActive(false);
            var bulletViewModel = bulletGameObject.GetComponent<BulletViewModel>();
            
            if (bulletViewModel != null)
            {
                bulletViewModel.BulletGameObject = bulletGameObject; //TODO remove dis, use .gameobject
                bulletViewModel.Damage = _playerState.CurrentCannonLoadout.Damage; //TODO Projectyle damage
                bulletViewModel.Speed = _playerState.CurrentCannonLoadout.ProjectileSpeed;
                bulletViewModel.RigidBody = bulletGameObject.GetComponent<Rigidbody2D>();
                
                bulletViewModel.OnCollision += OnBulletCollision;
            }
            
            //bulletGameObject.SetActive(true); //kek
            return bulletViewModel;
        }

        private void OnBulletCollision(object sender, EventArgs e)
        {
            if (sender is BulletViewModel)
            {
                BulletViewModel bulletViewModel = (BulletViewModel) sender;
                Destroy(bulletViewModel.gameObject);
            }
        }
    }
}