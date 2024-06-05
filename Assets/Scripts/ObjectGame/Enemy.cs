using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Enemy : GameObjectBase
    {
        [Header("Enemy Settings")] [SerializeField]
        private float velocityLimit = 1.5f;

        [SerializeField] private float damageBullet = 4f;
        [SerializeField] private Animator animatorEnemy;
        [SerializeField] private GameObject bloodHit;
        [SerializeField] private float timeHiddenBodyEnemy = 0.5f;
        [SerializeField] public EnemyStats enemyStatsDefault;

        private EnemyStats _enemyStats;
        private Rigidbody2D _rigidbody2DEnemy;
        private GameObject _player;
        private bool _isDeath;
        private float _hp;

        private static readonly int DEATH = Animator.StringToHash(Constants.AnimatorConsts.DEATH);

        public override void OnEnable()
        {
            base.OnEnable();
            OnInit();
        }

        private void OnInit()
        {
            _enemyStats = ScriptableObject.CreateInstance<EnemyStats>();
            _enemyStats.SetValue(enemyStatsDefault);
            
            Debug.Log("enemyStats.hp: " + enemyStatsDefault.hp);
            Debug.Log("_enemyStats.hp: " + _enemyStats.hp);

            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _player = GameManage.Ins.Player;
            _isDeath = false;
            _hp = enemyStatsDefault.hp;

            if (bloodHit)
            {
                bloodHit.SetActive(false);
            }

            if (gameObject.layer == LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER))
            {
                gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.ENEMY_LAYER);
            }
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (_isDeath)
            {
                return;
            }

            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var positionPlayer = _player.transform.position;
            var positionEnemy = this.transform.position;

            var velocity = Utils.GetVelocity(positionPlayer, positionEnemy, velocityLimit);

            this.transform.rotation = Utils.GetFlipAmation(velocity);

            _rigidbody2DEnemy.velocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.TagsConsts.BULLET))
            {
                Debug.Log("OnTriggerEnter2D");
                // ShootEnemy();
            }

            if (col.CompareTag(Constants.TagsConsts.PLAYER))
            {
                HitPlayer(col);
            }
        }

        private void HitPlayer(Collider2D col)
        {
            // var player = col.GetComponent<Player>();
            // player.TakeDamage(enemyStats.damage);

            //TODO Monsters collide with players
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.CompareTag(Constants.TagsConsts.BULLET))
            {
                ShootEnemy();
            }
        }

        private void ShootEnemy()
        {
            // enemyStats.hp -= damageBullet;
            // if (enemyStats.hp > 0)

            _hp -= damageBullet;
            if (_hp > 0)
            {
                if (bloodHit) bloodHit.SetActive(true);
                return;
            }

            animatorEnemy.SetTrigger(DEATH);
            _isDeath = true;
            _rigidbody2DEnemy.velocity = new Vector2();

            CollectableManage.Ins.OnSpawn(transform.position);

            //TODO
            gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER);
            // HiddenGameObjectWaitForSeconds(timeDelayHiddenObject);
            this.OnDespawn(timeHiddenBodyEnemy);
        }
    }
}