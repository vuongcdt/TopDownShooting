using System;
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