﻿using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Enemy : ObjectBase
    {
        [SerializeField] private float velocityLimit = 1.5f;
        [SerializeField] private float hpEnemy = 10f;
        [SerializeField] private float damageBullet = 4f;
        [SerializeField] private Animator animatorEnemy;
        [SerializeField] private GameObject bloodSplatter;
        [SerializeField] private LayerMask enemyLayer;

        private Rigidbody2D _rigidbody2DEnemy;
        private bool _isDeath;
        private GameObject _player;
        private static readonly int DEATH = Animator.StringToHash(Constants.Animator.DEATH);

        public void ReBorn()
        {
            _isDeath = false;
            hpEnemy = 10f;
            bloodSplatter.SetActive(false);
            //TODO
            // if (gameObject.layer == 0) gameObject.layer = enemyLayer;
        }

        private void Start()
        {
            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _player = GameManage.Ins.Player;
            bloodSplatter.SetActive(false);
        }

        private void Update()
        {
            if (_isDeath)
            {
                return;
            }

            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var positionPlayer = _player.transform.position;
            var positionEnemy = gameObject.transform.position;

            var velocity = Utils.GetVelocity(positionPlayer, positionEnemy, velocityLimit);

            gameObject.transform.localScale = Utils.SetFlipAmation(velocity);

            _rigidbody2DEnemy.velocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.Tags.BULLET))
            {
                ShootEnemy(col.transform.position);
            }

            if (col.CompareTag(Constants.Tags.PLAYER))
            {
                //TODO
                Debug.Log("111 player va cham enemy " + gameObject.name);
                HitPlayer();
            }
        }

        private void HitPlayer()
        {
            //TODO Monsters collide with players
        }

        private void ShootEnemy(Vector2 positionBullet)
        {
            hpEnemy -= damageBullet;

            if (hpEnemy > 0)
            {
                bloodSplatter.SetActive(true);
                Invoke(nameof(HiddenWound), 0.3f);
                return;
            }

            animatorEnemy.SetTrigger(DEATH);
            _isDeath = true;
            _rigidbody2DEnemy.velocity = new Vector2();

            CollectableManage.Ins.Spawn(transform.position);

            //TODO
            // gameObject.layer = 0;
            Invoke(nameof(SetDeathEnemy), 0.5f);
        }

        private void HiddenWound()
        {
            bloodSplatter.SetActive(false);
        }

        private void SetDeathEnemy()
        {
            gameObject.ObjectDisappear();
        }
    }
}