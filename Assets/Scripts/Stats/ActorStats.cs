using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class ActorStats : StatsBase
    {
        [field: Header("Base Stats")] 
        public float hp;
        public float damage;
        public float moveSpeed;
        public int level = 1;

        public override void SetValue(StatsBase statsBase)
        {
            var actorStats =  ((ActorStats)statsBase);
            var upgradeFormula = Utils.GetUpgradeFormula(actorStats.level);
            
            this.hp = actorStats.hp * upgradeFormula;
            this.damage = actorStats.damage* upgradeFormula;
            this.moveSpeed = actorStats.moveSpeed* upgradeFormula;
            this.level = actorStats.level;
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