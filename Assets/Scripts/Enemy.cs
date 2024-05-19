using Common;
using UnityEngine;

namespace Scritps
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float velocityLimit = 1.5f;
        [SerializeField] private float hpEnemy = 10f;
        [SerializeField] private float damageBullet = 4f;
        [SerializeField] private Animator animatorEnemy;

        private Rigidbody2D _rigidbody2DEnemy;
        private bool _isDeath;
        private GameObject _player;
        private static readonly int DEATH = Animator.StringToHash(Constants.Animator.DEATH);

        public void ReBorn()
        {
            _isDeath = false;
        }

        private void Start()
        {
            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _player = GameManage.Ins.Player;
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
                ShootEnemy(col);
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

        private void ShootEnemy(Collider2D col)
        {
            hpEnemy -= damageBullet;
            if (hpEnemy < 0)
            {
                animatorEnemy.SetTrigger(DEATH);
                _isDeath = true;
                _rigidbody2DEnemy.velocity = new Vector2();
                
                Invoke(nameof(SetDeathEnemy),0.5f);
            }
        }

        private void SetDeathEnemy()
        {
            gameObject.SetActive(false);
        }
    }
}