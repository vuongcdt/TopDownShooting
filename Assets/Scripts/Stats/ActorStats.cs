using System;
using Common;
using UnityEngine;

namespace Scritps
{
    public class ActorStats : StatsBase
    {
        [Header("Base Stats")] public float hp;
        public float damage;
        public float moveSpeed;

        public override void Init(StatsBase statsBase)
        {
            var actorStats = (ActorStats)statsBase;

            this.hp = actorStats.hp;
            this.damage = actorStats.damage;
            this.moveSpeed = actorStats.moveSpeed;
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