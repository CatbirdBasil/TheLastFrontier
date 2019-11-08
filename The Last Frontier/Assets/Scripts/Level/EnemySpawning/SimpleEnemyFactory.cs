using System;
using System.Collections.Generic;
using TLFGameLogic.Model;
using UnityEngine;
using Zenject;

namespace TLFUILogic
{
    public class SimpleEnemyFactory : ScriptableObject, IEnemyFactory
    {
        private List<EnemyViewModel> _createdEnemies;
        [Inject] private EnemyPrefabDictionary _enemyPrefabDictionary;

        public void WarmUp(Dictionary<EnemyType, int> estimatedEnemiesOnScreen)
        {
            var estimatedMax = 0;
            foreach (var estimated in estimatedEnemiesOnScreen.Values) estimatedMax += estimated;

            _createdEnemies = new List<EnemyViewModel>(estimatedMax);
        }

        public EnemyViewModel GetEnemy(Enemy enemy)
        {
            var prefab = _enemyPrefabDictionary.GetEnemyPrefab(enemy.EnemyType);
            var enemyGameObject = Instantiate(prefab);
            var enemyViewModel = enemyGameObject.AddComponent<EnemyViewModel>();

            enemyViewModel.EnemyGameObject = enemyGameObject;
            enemyViewModel.Enemy = enemy;
            enemyViewModel.Rigidbody = enemyGameObject.GetComponent<Rigidbody2D>();

            _createdEnemies.Add(enemyViewModel);
            enemy.LethalDamage += EnemyOnLethalDamage;
//            enemyViewModel.Rigidbody.AddForce(-spawnPointTransform.right * enemy.Speed * 10f, ForceMode2D.Force);
            return enemyViewModel;
        }

        private void EnemyOnLethalDamage(object sender, EventArgs e)
        {
            if (sender is Enemy)
            {
                var enemyViewModel = _createdEnemies.Find(x => x.Enemy.Equals(sender as Enemy));
                _createdEnemies.Remove(enemyViewModel);
                Destroy(enemyViewModel.EnemyGameObject);
            }
        }
    }
}