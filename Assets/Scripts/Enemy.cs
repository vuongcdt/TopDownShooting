﻿using Common;
using UnityEngine;

namespace Scritps
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [SerializeField] private float velocityLimit = 1.5f;
        [SerializeField] private float hpEnemy = 10f;
        [SerializeField] private float damageBullet = 4f;

        private Rigidbody2D _rigidbody2DEnemy;

        private void Start()
        {
            _rigidbody2DEnemy = enemy.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var positionPlayer = player.transform.position;
            var positionEnemy = enemy.transform.position;
            
            var velocity = TouchController.GetVelocity(positionPlayer, positionEnemy, velocityLimit);

            enemy.transform.localScale = TouchController.SetFlipAmation(velocity);

            _rigidbody2DEnemy.velocity = velocity;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constans.Tags.Bullet))
            {
                hpEnemy -= damageBullet;
                if(hpEnemy < 0 )
                {
                    DestroyEnemy();
                }
            }
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}