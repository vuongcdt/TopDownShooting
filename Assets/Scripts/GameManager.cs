using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using GUI;
using ObjectGame;
using Stats;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject player, enemy, bullet, coinCollectable, diamondCollectable, healthCollectable, lifeCollectable;

    public bool isClearData;

    private float _timeCountDown;
    private bool _isSave;
    private int _enemyCount;
    private PlayerStats _playerStats;
    private PlayerStats _playerStatsDefault;
    private UIManager _uiManager;

    public GameObject Player => player;

    public int EnemyCount
    {
        get => _enemyCount;
        set => _enemyCount = value;
    }

    public void AddCoin(int value)
    {
        _playerStats.coinCount += value;
        _uiManager.SetCoinCount(_playerStats.coinCount);
    }
    
    public void AddXp(int value)
    {
        _playerStats.xp += value;
        var xpMax = _playerStats.GetXpUp(_playerStats.level);
            
        while (_playerStats.xp >= xpMax)
        {
            _playerStats.level++;
            xpMax = _playerStats.GetXpUp(_playerStats.level);
        }
        
        _uiManager.SetLevelBar(_playerStats);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public void AddHp(int hpBonus)
    {
        _playerStats.hp += hpBonus;
        
        var maxHp = _playerStatsDefault.GetMaxHp(_playerStats.level);
        _uiManager.SetHpBar(_playerStats.hp, maxHp);
    }
    
    public void AddLife()
    {
        _playerStats.lifeCount ++;
        _uiManager.SetLifeBar(_playerStats.lifeCount);
    }
    private void Start()
    {
        _playerStatsDefault = GameStats.Ins.PlayerStats;
        _uiManager = UIManager.Ins;
        _playerStats = player.GetComponent<Player>().PlayerStats;
        LoadData();
        SetValueTextUI();
    }

    private void LoadData()
    {
        if (isClearData)
        {
            Prefs.ClearData();
            _playerStats = ScriptableObject.CreateInstance<PlayerStats>();
            _playerStats.Init(_playerStatsDefault);
            
            Debug.Log(_playerStats.xp);
            Debug.Log(_playerStats.xp);
        }
        else
        {
            LoadDataFromPrefs();
        }
    }


    private void SetValueTextUI()
    {
        _uiManager.SetLevelBar(_playerStats);

        var maxHp = _playerStatsDefault.GetMaxHp(_playerStats.level);

        _uiManager.SetHpBar(_playerStats.hp, maxHp);

        _uiManager.SetLifeBar(_playerStats.lifeCount);

        _uiManager.SetCoinCount(_playerStats.coinCount);
    }

    private void LoadDataFromPrefs()
    {
        JsonHelper jsonHelper = new(new List<GameData>());
        JsonUtility.FromJsonOverwrite(Prefs.MapData, jsonHelper);

        GameObject objectIns;
        jsonHelper.gameDatas.ForEach(e =>
        {
            switch (e.type)
            {
                case Enums.ObjectType.Enemy:
                    objectIns = enemy;
                    break;
                case Enums.ObjectType.CoinCollectable:
                    objectIns = coinCollectable;
                    break;
                case Enums.ObjectType.DiamondCollectable:
                    objectIns = diamondCollectable;
                    break;
                case Enums.ObjectType.HealthPotionCollectable:
                    objectIns = healthCollectable;
                    break;
                case Enums.ObjectType.LifeCollectable:
                    objectIns = lifeCollectable;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Instantiate(objectIns, e.position, Quaternion.identity);
        });
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        CheckSaveGame(pauseStatus);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        CheckSaveGame(!hasFocus);
    }

    private void CheckSaveGame(bool isPause)
    {
        if (isPause)
        {
            SaveGame();
        }

        if (!isPause)
        {
            _isSave = false;
        }
    }

    private void SaveGame()
    {
        if (_isSave) return;
        _isSave = true;

        var gameDatas = Utils.GameObjectsStore
            .Where(e => e.enabled && e.stats is not { type: Enums.ObjectType.Bullet })
            .Select(e => new GameData(e.transform.position, e.stats.type, e.stats))
            .ToList();

        var jsonHelper = new JsonHelper(gameDatas);

        Prefs.MapData = JsonUtility.ToJson(jsonHelper);
    }

}