using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Enemy Stats")]
    public class EnemyStats: ActorStats
    {
        [Header("Enemy Stats:")] 
        public float xpBonus ;
        public int countEnemyPerLevel = 2;
        public float timeTakeDamage = 0.5f;

        public override void OnInit(StatsBase statsBase)
        {
            var enemyStats = (EnemyStats)statsBase;
            GameManage.Ins.EnemyCount++;
            var upgradeFormula = Utils.GetUpgradeFormula(this.level);
            
            enemyStats.level = GetLevelEnemy(GameManage.Ins.EnemyCount);
            base.OnInit(statsBase);

            this.timeTakeDamage = enemyStats.timeTakeDamage;
            this.xpBonus = enemyStats.xpBonus * upgradeFormula;
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