using System;
using Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public abstract class StatsBase : ScriptableObject
    {
        public Enums.ObjectType type;
        public int level = 1;

        public abstract void OnInit(StatsBase statsBase);
        public abstract void Save();
        public abstract void Load();
        
        public abstract void Upgrade(Action OnSuccess = null, Action OnFailed = null);
        public abstract bool IsMaxLevel();
    }
}