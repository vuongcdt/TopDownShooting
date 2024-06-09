using System;
using System.Collections;
using Common;
using Stats;
using UnityEngine;

namespace ObjectGame
{
    public class Collectable : GameObjectBase
    {
        [Header("Collectable Settings")] [SerializeField]
        private float endTimeDespawn = 5f;

        private Animator _animatorCollectable;
        private Rigidbody2D _rigidbody2D;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Ins;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            OnInit();
        }

        private void OnInit()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animatorCollectable = gameObject.GetComponent<Animator>();
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLIP);
            StartCoroutine(EndTimeHiddenCollectable());
        }

        private IEnumerator EndTimeHiddenCollectable()
        {
            yield return new WaitForSeconds(delayTimeDespawn - endTimeDespawn);
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLASH);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.TagsConsts.PLAYER))
            {
                this.OnDespawn(0f);
                _rigidbody2D.velocity = Vector2.zero;

                var upgradeFormula = Utils.GetUpgradeFormula(stats.level);

                switch (stats.type)
                {
                    case Enums.ObjectType.CoinCollectable:
                    {
                        var coinStats = (CoinStats)stats;
                        var coinBonus = Mathf.CeilToInt(coinStats.coinStartLevel * upgradeFormula);
                        _gameManager.AddCoin(coinBonus);
                        break;
                    }
                    case Enums.ObjectType.HealthPotionCollectable:
                    {
                        var healthStats = (HealthStats)stats;
                        var hpBonus = Mathf.CeilToInt(healthStats.healthStartLevel * upgradeFormula);
                        _gameManager.AddHp(hpBonus);
                        break;
                    }
                    case Enums.ObjectType.LifeCollectable:
                        _gameManager.AddLife();
                        break;
                    case Enums.ObjectType.DiamondCollectable:
                    {
                        var diamondStats = (DiamondStats)stats;
                        var diamondBonus = Mathf.CeilToInt(diamondStats.lifeStartLevel * upgradeFormula);
                        _gameManager.AddCoin(diamondBonus);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}