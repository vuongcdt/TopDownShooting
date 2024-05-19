using Common;
using UnityEngine;

namespace Scritps
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float velocityLimit = 1.5f;
        [SerializeField] private float hpEnemy = 10f;
        [SerializeField] private float damageBullet = 4f;

        private Rigidbody2D _rigidbody2DEnemy;
        private Player _player;

        private void Start()
        {
            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _player = GameManage.Ins.Player;
        }

        private void Update()
        {
            if (!gameObject.activeSelf)
            {
                Debug.Log(gameObject.activeSelf);
                return;
            }
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            var positionPlayer = _player.transform.position;
            var positionEnemy = gameObject.transform.position;
            
            var velocity = TouchController.GetVelocity(positionPlayer, positionEnemy, velocityLimit);

            gameObject.transform.localScale = TouchController.SetFlipAmation(velocity);

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
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}