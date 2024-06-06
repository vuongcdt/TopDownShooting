using System;
using Common;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Bullet Stats")]
    public class BulletStats : StatsBase
    {
        [Header("Base Stats:")] 
        public float damage;
    
        public float reloadTime;
        public float speedBullet = 30;
        
        public override void OnInit(StatsBase statsBase)
        {
            var bulletStats = (BulletStats)statsBase;
            var upgradeFormula = Utils.GetUpgradeFormula(bulletStats.level);
            
            this.damage = bulletStats.damage * upgradeFormula;
            this.reloadTime =  GetReloadTime(bulletStats.reloadTime);
        }

        private float GetReloadTime(float bulletStatsReloadTime)
        {
            return bulletStatsReloadTime / Mathf.Pow(0.9f,level);
        }


        public override void Save()
        {
        }

        public override void Load()
        {
          
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
        }

        public override bool IsMaxLevel()
        {
            return false;
        }
    }
}