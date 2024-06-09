using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Stats
{
    [CreateAssetMenu(fileName = "Player Stats")]
    [Serializable]
    public class PlayerStats : ActorStats
    {
        public Vector3 position;
        public int lifeCount = 4;
        public int coinCount;

        [Header("Level Up Base:")] public int maxLevel = 100;
        public int xp = 0;
        [FormerlySerializedAs("xpLevelFirst")] public int xpFirstLevel = 10;

        public override void Init(StatsBase statsBase)
        {
            var playerStats = (PlayerStats)statsBase;
            base.Init(playerStats);

            this.position = playerStats.position;
            this.maxLevel = playerStats.maxLevel;
            this.xp = playerStats.xp;
            this.lifeCount = playerStats.lifeCount;
            this.coinCount = playerStats.coinCount;
        }

        public float GetMaxHp(int levelCurrent)
        {
            return this.hp * Utils.GetUpgradeFormula(levelCurrent - 1);
        }

        public float GetXpUp(int levelValue)
        {
            return this.xpFirstLevel * levelValue * Utils.GetUpgradeFormula(levelValue);
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