using System;
using System.Collections;
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
        public Enemy Enemy { get; private set; }

        public Rigidbody2D RigidBody { get; set; }
        
        public SpriteRenderer SpriteRenderer { get; set; }

        public Animator Animator { get; set; }

        private const string AnimatorLethalDamageTriggerName = "Lethal Damage";
        private const string AnimatorSpeedParameterName = "Speed";
        private const string AnimatorAttackTriggerName = "Attack";
        private const string AnimatorReceiveDamageTriggerName = "Receive Damage";

        public bool IsAlive { get; private set; }

        protected float _timeBeforeNextAttack = 0.2f;
        
        private Base _сurrentBase;

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

        void FixedUpdate()
        {
            if (IsAlive && (RigidBody.velocity == Vector2.zero))
            {
                if (this.transform.position.x > -9.15f)
                    Move(-9.15f);
                else
                    Attack();
            }
        }

        public void Move(float target)
        {
            Animator.SetFloat(AnimatorSpeedParameterName, Enemy.Speed * 0.01f);
            RigidBody.MovePosition(new Vector2(transform.position.x - Enemy.Speed * 0.01f, transform.position.y));
        }

        public void TakeDamage(float damage)
        {
            SpriteRenderer.material.color = new Color32(255, 180, 180, 255);
            StartCoroutine(NormalizeColor());
            RigidBody.AddForce(transform.right * 0.01f, ForceMode2D.Impulse); // TODO Remove hardcode
            Animator.SetFloat(AnimatorSpeedParameterName, 0);
            Animator.SetTrigger(AnimatorReceiveDamageTriggerName);
            Enemy.TakeDamage(damage);
        }

        public IEnumerator NormalizeColor()
        {
            byte currColor = 180;
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.1f);
                currColor = (byte) (currColor + 25);
                SpriteRenderer.material.color = new Color32(255,currColor,currColor, 255);
            }
        }

        private void Attack()
        {
            Animator.SetFloat(AnimatorSpeedParameterName, 0);
            
            if (_timeBeforeNextAttack <= 0)
            {
                Animator.SetTrigger(AnimatorAttackTriggerName);
                _сurrentBase.TakeDamage(Enemy.Damage);
                _timeBeforeNextAttack = 1f / Enemy.AttackSpeed;
            }
            else
            {
                _timeBeforeNextAttack -= Time.deltaTime;
            }
        }

        private void EnemyOnLethalDamage(object sender, EventArgs e)
        {
            Animator.ResetTrigger(AnimatorReceiveDamageTriggerName);
            IsAlive = false;
            Animator.SetTrigger(AnimatorLethalDamageTriggerName);
        }

        public void SetBase(Base _base)
        {
            _сurrentBase = _base;
        }
    }
}