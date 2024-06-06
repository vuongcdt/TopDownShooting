using System;
using Common;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Player Stats")]
    [Serializable]
    public class PlayerStats : ActorStats
    {
        public Vector3 position;

        [ Header("Level Up Base:")] 
        public int maxLevel = 100;
        public float xp = 0;

        public override void OnInit(StatsBase statsBase)
        {
            var playerStats = (PlayerStats)statsBase;
            base.OnInit(playerStats);

            this.position = playerStats.position;
            this.maxLevel = playerStats.maxLevel;
            this.xp = playerStats.xp;
        }

        public override void Save()
        {
            // Prefs.PlayerData = JsonUtility.ToJson(this);
        }

        public override void Load()
        {
            // if (!string.IsNullOrEmpty(Prefs.PlayerData))
            // {
            //     JsonUtility.FromJsonOverwrite(Prefs.PlayerData, this);
            // }
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
            // while (xp >= levelUpXpRequire && !IsMaxLevel())
            // {
            //     level++;
            //     xp -= levelUpXpRequire;
            //     hp += hpUp * Utils.GetUpgradeFormula(level);
            //     levelUpXpRequire += levelUpXpRequireUp * Utils.GetUpgradeFormula(level);
            //     Save();
            //     OnSuccess?.Invoke();
            // }
            //
            // if (xp <= levelUpXpRequire || IsMaxLevel())
            // {
            //     OnFailed?.Invoke();
            // }
        }

        public override bool IsMaxLevel()
        {
            return level >= maxLevel;
        }
    }
}