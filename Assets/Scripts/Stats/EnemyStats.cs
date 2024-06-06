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
        public float timeTakeDamge = 0.2f;

        public override void OnInit(StatsBase statsBase)
        {
            var enemyStats = (EnemyStats)statsBase;
            GameManage.Ins.EnemyCount++;

            enemyStats.level = GetLevelEnemy(GameManage.Ins.EnemyCount);
            base.OnInit(statsBase);

            this.timeTakeDamge = enemyStats.timeTakeDamge;
            this.xpBonus = enemyStats.xpBonus;
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