using System;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "Coin Stats")]
    public class CoinStats:StatsBase
    {
        public int coinStartLevel = 4;
        
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