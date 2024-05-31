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

        [field: Header("Level Up Base:")] 
        public int level = 1;
        public int maxLevel = 100;
        public float xp = 0;
        public float levelUpXpRequire = 10;

        [field: Header("Level Up:")] 
        public float levelUpXpRequireUp = 10;
        public float hpUp = 10;

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