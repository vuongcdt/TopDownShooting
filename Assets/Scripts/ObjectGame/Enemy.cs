using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Enemy : MyMonoBehaviour
    {
        [SerializeField] private float velocityLimit = 1.5f;
        [SerializeField] private float hpEnemy = 10f;
        [SerializeField] private float damageBullet = 4f;
        [SerializeField] private Animator animatorEnemy;
        [SerializeField] private GameObject bloodHit;
        [SerializeField] private float timeHitPlayer = 0.2f;
        [SerializeField] private float timeHiddenBodyEnemy = 0.5f;

        private Rigidbody2D _rigidbody2DEnemy;
        private bool _isDeath;
        private GameObject _player;
        private float _hpEnemy;

        private static readonly int DEATH = Animator.StringToHash(Constants.AnimatorConsts.DEATH);

        public void AutoHiddenByTime()
        {
            _isDeath = false;
            _hpEnemy = hpEnemy;
            
            if (bloodHit)
            {
                bloodHit.SetActive(false);
            }
            
            if (gameObject.layer == LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER))
            {
                gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.ENEMY_LAYER);
            }
        }

        private void Start()
        {
            _hpEnemy = hpEnemy;
            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _player = GameManage.Ins.Player;
            bloodHit.SetActive(false);
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
            if (col.CompareTag(Constants.TagsConsts.BULLET))
            {
                ShootEnemy();
            }

            if (col.CompareTag(Constants.TagsConsts.PLAYER))
            {
                //TODO

                // ActionWaitForSeconds(HitPlayer, timeHitPlayer);
                HitPlayer();
            }
        }

        private void HitPlayer()
        {
            Debug.Log("111 player va cham enemy " + gameObject.name);

            //TODO Monsters collide with players
        }

        private void ShootEnemy()
        {
            _hpEnemy -= damageBullet;

            if (_hpEnemy > 0)
            {
                if (bloodHit) bloodHit.SetActive(true);
                // HiddenBloodHit();
                // Invoke(nameof(HiddenBloodHit), timeHiddenBloodHit);
                return;
            }

            animatorEnemy.SetTrigger(DEATH);
            _isDeath = true;
            _rigidbody2DEnemy.velocity = new Vector2();

            CollectableManage.Ins.Spawn(transform.position);

            //TODO
            gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER);
            HiddenGameObjectWaitForSeconds(timeHiddenBodyEnemy);
        }

        // public override void ReBorn()
        // {
        // }
    }
}