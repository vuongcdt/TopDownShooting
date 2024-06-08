using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Enemy Stats")]
    public class EnemyStats : ActorStats
    {
        [Header("Enemy Stats:")] public int xpBonus;
        public int countEnemyPerLevel = 10;
        public float timeTakeDamage = 0.5f;

        public override void Init(StatsBase statsBase)
        {
            var enemyStats = (EnemyStats)statsBase;
            GameManage.Ins.EnemyCount++;

            enemyStats.level = GetLevelEnemy(GameManage.Ins.EnemyCount);
            base.Init(statsBase);

            this.timeTakeDamage = enemyStats.timeTakeDamage;
            this.xpBonus = Mathf.CeilToInt(enemyStats.xpBonus);
            this.type = Enums.ObjectType.Enemy;
        }

        private int GetLevelEnemy(int enemyCount)
        {
            return enemyCount / countEnemyPerLevel + 1;
        }

        public override void Save()
        {
            base.Save();
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
            base.Upgrade(OnSuccess, OnFailed);
        }

        public override bool IsMaxLevel()
        {
            return base.IsMaxLevel();
        }
    }
}