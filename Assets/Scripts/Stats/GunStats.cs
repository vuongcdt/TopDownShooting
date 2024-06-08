using System;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(menuName = "Gun Stats")]
    public class GunStats:StatsBase
    {
        [Header("Gun Setting:")]
        public float timeShooting = 1;
        public float enemyDectionRadius = 3;
        
        public override void Init(StatsBase statsBase)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
            throw new NotImplementedException();
        }

        public override bool IsMaxLevel()
        {
            throw new NotImplementedException();
        }
    }
}