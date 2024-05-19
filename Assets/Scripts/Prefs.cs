using Common;
using UnityEngine;

namespace Scritps
{
    public static class Prefs
    {
        public static int Coin
        {
            get => PlayerPrefs.GetInt(Constants.PrefConsts.COIN_DATA_KEY, 0);
            set => PlayerPrefs.GetInt(Constants.PrefConsts.COIN_DATA_KEY, value);
        }
        
        public static string PlayerData
        {
            get => PlayerPrefs.GetString(Constants.PrefConsts.PLAYER_DATA_KEY);
            set => PlayerPrefs.GetString(Constants.PrefConsts.PLAYER_DATA_KEY, value);
        }
        
        public static string EnemyData
        {
            get => PlayerPrefs.GetString(Constants.PrefConsts.ENEMY_DATA_KEY);
            set => PlayerPrefs.GetString(Constants.PrefConsts.ENEMY_DATA_KEY, value);
        }
        
        public static string WeaponData
        {
            get => PlayerPrefs.GetString(Constants.PrefConsts.WEAPON_DATA_KEY);
            set => PlayerPrefs.GetString(Constants.PrefConsts.WEAPON_DATA_KEY, value);
        }
        
        public static bool IsEnoughCoins(int value)
        {
            return Coin >= value;
        }
    }
}