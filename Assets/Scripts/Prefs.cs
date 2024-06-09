using Common;
using UnityEngine;

public static class Prefs
{
    public static int Coin
    {
        get => PlayerPrefs.GetInt(Constants.PrefConsts.COIN_DATA_KEY, 0);
        set => PlayerPrefs.SetInt(Constants.PrefConsts.COIN_DATA_KEY, value);
    }
        
    public static string MapData
    {
        get => PlayerPrefs.GetString(Constants.PrefConsts.MAP_DATA_KEY);
        set => PlayerPrefs.SetString(Constants.PrefConsts.MAP_DATA_KEY, value);
    }
         
    public static string PlayerData
    {
        get => PlayerPrefs.GetString(Constants.PrefConsts.PLAYER_DATA_KEY);
        set => PlayerPrefs.SetString(Constants.PrefConsts.PLAYER_DATA_KEY, value);
    }
        
    public static string EnemyData
    {
        get => PlayerPrefs.GetString(Constants.PrefConsts.ENEMY_DATA_KEY);
        set => PlayerPrefs.SetString(Constants.PrefConsts.ENEMY_DATA_KEY, value);
    }
        
    public static string WeaponData
    {
        get => PlayerPrefs.GetString(Constants.PrefConsts.BULLET_DATA_KEY);
        set => PlayerPrefs.SetString(Constants.PrefConsts.BULLET_DATA_KEY, value);
    }       
    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
        
    public static bool IsEnoughCoins(int value)
    {
        return Coin >= value;
    }
}