using Common;
using Stats;
using UnityEngine;

namespace ObjectGame
{
    public class Enemy : GameObjectBase
    {
        [SerializeField] private Animator animatorEnemy;
        [SerializeField] private GameObject bloodHit;
        [SerializeField] private float timeDespawnEnemy = 0.5f;
        [SerializeField] public EnemyStats enemyStatsDefault;

        private Rigidbody2D _rigidbody2DEnemy;
        private GameManager _gameManager;
        private bool _isDeath;
        private float _hp;
        private float _takeDameCount;
        private bool _isTakeDame;

        private static readonly int DEATH_ANIM = Animator.StringToHash(Constants.AnimatorConsts.DEATH);

        public override void OnEnable()
        {
            base.OnEnable();
            OnInit();
        }

        private void OnInit()
        {
            stats = ScriptableObject.CreateInstance<EnemyStats>();
            stats.Init(enemyStatsDefault);

            _rigidbody2DEnemy = gameObject.GetComponent<Rigidbody2D>();
            _gameManager = GameManager.Ins;
            _isDeath = false;
            _hp = ((EnemyStats)stats).hp;

            if (bloodHit)
            {
                bloodHit.SetActive(false);
            }

            if (gameObject.layer == LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER))
            {
                gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.ENEMY_LAYER);
            }
        }

        protected void FixedUpdate()
        {
            if (_isDeath)
            {
                return;
            }

            MoveToPlayer();
            SetTimeTakeDamage();
        }

        private void SetTimeTakeDamage()
        {
            if (!_isTakeDame) return;

            _takeDameCount += Time.fixedDeltaTime;
            var enemyStats = (EnemyStats)stats;
            if (_takeDameCount > enemyStats.timeTakeDamage)
            {
                _gameManager.TakeDamage(enemyStats.damage);
                _takeDameCount = 0;
            }
        }

        private void MoveToPlayer()
        {
            var positionPlayer = _gameManager.Player.transform.position;
            var positionEnemy = this.transform.position;

            var velocity = Utils.GetVelocity(positionPlayer, positionEnemy, ((EnemyStats)stats).moveSpeed);

            this.transform.rotation = Utils.GetFlipAmation(velocity);

            _rigidbody2DEnemy.velocity = velocity;
        }

        private void OnTriggerStay2D(Collider2D col2D)
        {
            if (col2D.CompareTag(Constants.TagsConsts.PLAYER))
            {
                _isTakeDame = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col2D)
        {
            if (col2D.CompareTag(Constants.TagsConsts.PLAYER))
            {
                _isTakeDame = false;
                _takeDameCount = 0;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.CompareTag(Constants.TagsConsts.BULLET))
            {
                var statsBullet = (BulletStats)collision2D.gameObject.GetComponent<Bullet>().stats;
                ShootEnemy(statsBullet.damage);
            }
        }

        private void ShootEnemy(float damageBullet)
        {
            _hp -= damageBullet;
            if (_hp > 0)
            {
                bloodHit.SetActive(true);
                return;
            }

            animatorEnemy.SetTrigger(DEATH_ANIM);
            _isDeath = true;
            _rigidbody2DEnemy.velocity = new Vector2();

            CollectableManager.Ins.OnSpawn(transform.position,stats.level);

            gameObject.layer = LayerMask.NameToLayer(Constants.LayerConsts.DEFAULT_LAYER);
            this.OnDespawn(timeDespawnEnemy);
            
            AddXpToPlayer();
        }

        private void AddXpToPlayer()
        {
            var enemyStats = (EnemyStats)stats;

            var xpBonus = enemyStats.xpBonus * Utils.GetUpgradeFormula(enemyStats.level);
            _gameManager.AddXp(Mathf.CeilToInt(xpBonus));
        }
    }
}