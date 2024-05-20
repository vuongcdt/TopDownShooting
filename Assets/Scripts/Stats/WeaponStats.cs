﻿using System;
using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Weapon Stats")]
    public class WeaponStats : StatsBase
    {
        [Header("Base Stats:")] public int bullets;
        public float damage;
        public float timeShooting;
        public float reloadTime;
        public float enemyDectionRadius;

        [Header("Upgrade:")] 
        public int level;
        public int maxLevel;
        public float damageUp;
        public float reloadTimeUp;
        public int upgradePrice;
        public int upgradePriceUp;

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
            throw new NotImplementedException();
        }

        public override bool IsMaxLevel()
        {
            return level >= maxLevel;
        }
    }
}