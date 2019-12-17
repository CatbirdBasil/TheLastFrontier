using System;
using Level;
using Level.LevelEventArgs;
using Level.Model.Cannon;
using ModestTree;
using TLFGameLogic.Model;
using TLFGameLogic.Model.BaseData;
using UnityEngine;
using Zenject;


namespace TLFUILogic
{
    public class EnemyViewModel : MonoBehaviour
    {
        [Inject] private PlayerState _playerState;
        public Enemy Enemy { get; private set; }

        public Rigidbody2D RigidBody { get; set; }
        
        public Animator Animator { get; set; }

        private const string AnimatorLethalDamageTriggerName = "Lethal Damage";
        private const string AnimatorSpeedParameterName = "Speed";
        private const string AnimatorAttackTriggerName = "Attack";

        public bool IsAlive { get; private set; }

        private Base CurrentBase;

        public void InitEnemy(Enemy enemy)
        {
            Enemy = enemy;
            IsAlive = true;
            Enemy.LethalDamage += EnemyOnLethalDamage;
        }

        private void OnDisable()
        {
            Enemy.LethalDamage -= EnemyOnLethalDamage;
        }

        void Update()
        {
            if (IsAlive)
            {
                if (this.transform.position.x > -12)
                    Move(-12);
                else
                    Attack();
            }
        }

        public void Move(int target)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target,this.transform.position.y), Enemy.Speed*0.01f);
            
        }

        public void TakeDamage(float damage)
        {
            Enemy.TakeDamage(damage);
        }

        public void Attack()
        {
            CurrentBase.TakeDamage(Enemy.Damage);
        }
        
        private void EnemyOnLethalDamage(object sender, EventArgs e)
        {
            IsAlive = false;
            Animator.SetTrigger(AnimatorLethalDamageTriggerName);
        }

        public void setBase(Base _base)
        {
            CurrentBase = _base;
        }
    }
}