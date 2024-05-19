using System;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Create Stats/Create Player Stats")]
    public class PlayerStats : ActorStats
    {
        [field: Header("Level Up Base:")] public int Level { get; set; }
        public int MaxLevel { get; set; }
        public float Xp { get; set; }
        public float LevelUpXpRequire { get; set; }

        [field: Header("Level Up:")] public float LevelUpXpRequireUp { get; set; }
        public float HpUp { get; set; }

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
            float upgradeFormula = (Level / 2 - 0.5f) * 0.5f;
            while (Xp >= LevelUpXpRequire && !IsMaxLevel())
            {
                Level++;
                Xp -= LevelUpXpRequire;
                Hp += HpUp * upgradeFormula;
                LevelUpXpRequire += LevelUpXpRequireUp * upgradeFormula;
                Save();
                OnSuccess?.Invoke();
            }

            if (Xp <= LevelUpXpRequire || IsMaxLevel())
            {
                OnFailed?.Invoke();
            }
        }

        public override bool IsMaxLevel()
        {
            return Level >= MaxLevel;
        }
    }
}