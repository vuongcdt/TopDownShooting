using System;
using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(fileName = "Life Stats")]
    public class LifeStats:StatsBase
    {
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