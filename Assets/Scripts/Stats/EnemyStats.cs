using System;
using Common;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Enemy Stats")]
    public class EnemyStats: ActorStats
    {
        [Header("Xp Bonus:")] 
        public float minXpBonus ;
        public float maxXpBonus ;
        
        [Header("Level Up:")] 
        public float damageUp ;
        public float hpUp ;

        public override void Save()
        {
            base.Save();
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
            base.Upgrade(OnSuccess, OnFailed);
        }

        public override bool IsMaxLevel()
        {
            return base.IsMaxLevel();
        }
    }
}