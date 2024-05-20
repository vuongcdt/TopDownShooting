using System;
using Common;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Player Stats")]
    public class PlayerStats : ActorStats
    {
        [field: Header("Level Up Base:")] 
        public int level ;
        public int maxLevel ;
        public float xp ;
        public float levelUpXpRequire ;

        [field: Header("Level Up:")] 
        public float levelUpXpRequireUp ;
        public float hpUp ;

        public override void Save()
        {
            Prefs.PlayerData = JsonUtility.ToJson(this);
        }

        public override void Load()
        {
            if (!string.IsNullOrEmpty(Prefs.PlayerData))
            {
                JsonUtility.FromJsonOverwrite(Prefs.PlayerData, this);
            }
        }

        public override void Upgrade(Action OnSuccess = null, Action OnFailed = null)
        {
            while (xp >= levelUpXpRequire && !IsMaxLevel())
            {
                level++;
                xp -= levelUpXpRequire;
                hp += hpUp * Utils.GetUpgradeFormula(level);
                levelUpXpRequire += levelUpXpRequireUp * Utils.GetUpgradeFormula(level);
                Save();
                OnSuccess?.Invoke();
            }

            if (xp <= levelUpXpRequire || IsMaxLevel())
            {
                OnFailed?.Invoke();
            }
        }

        public override bool IsMaxLevel()
        {
            return level >= maxLevel;
        }
    }
}