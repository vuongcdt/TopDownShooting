using System;
using UnityEngine;

namespace Scritps
{
    public class ActorStats:StatsBase
    {
        [field: Header("Base Stats")] 
        public float Hp { get; set; }
        public float Damage { get; set; }
        public float MoveSpeed { get; set; }
        
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