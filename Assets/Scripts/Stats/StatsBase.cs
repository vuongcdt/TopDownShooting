using System;
using Common;
using UnityEngine;

namespace Stats
{
    public abstract class StatsBase : ScriptableObject
    {
        public Enums.ObjectType type;
        public int level = 1;

        public abstract void Init(StatsBase statsBase);
        public abstract void Save();
        public abstract void Load();
        
        public abstract void Upgrade(Action OnSuccess = null, Action OnFailed = null);
        public abstract bool IsMaxLevel();
    }
}