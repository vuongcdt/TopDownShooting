using System;
using Common;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Enemy Stats")]
    public class EnemyStats: ActorStats
    {
        [Header("Xp Bonus:")] 
        public float xpBonus ;
        public int countEnemyPerLevel = 2;

        public override void SetValue(StatsBase statsBase)
        {
            var enemyStats = (EnemyStats)statsBase;
            GameManage.Ins.CountEnemy++;

            enemyStats.level = GetLevelEnemy();
            base.SetValue(statsBase);

            this.xpBonus = enemyStats.xpBonus;
            this.type = Enums.ObjectType.Enemy;
        }

        private int GetLevelEnemy()
        {
           return GameManage.Ins.CountEnemy / countEnemyPerLevel + 1;
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