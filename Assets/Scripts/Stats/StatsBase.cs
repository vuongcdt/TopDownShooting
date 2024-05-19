using System;
using UnityEngine;

namespace Scritps
{
    public abstract class StatsBase : ScriptableObject
    {
        public abstract void Save();
        public abstract void Load();
        public abstract void Upgrade(Action OnSuccess = null, Action OnFailed = null);
        public abstract bool IsMaxLevel();
    }
}