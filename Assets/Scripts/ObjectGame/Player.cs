using System;
using Common;
using Scritps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStatsDefault;
    
    private PlayerStats _playerStats;
    private float _hpTest;

    public PlayerStats PlayerStats
    {
        get => _playerStats;
        set => _playerStats = value;
    }

    private void Awake()
    {
        _playerStats = ScriptableObject.CreateInstance<PlayerStats>();
        _playerStats.Init(playerStatsDefault);
        GetPositionPlayer();
    }

    private void GetPositionPlayer()
    {
        transform.position = _playerStats.position;
    }

    private void FixedUpdate()
    { 
        _playerStats.position = transform.position;
        _hpTest = _playerStats.hp;
        
        if (_playerStats.hp < 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game over");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Constants.TagsConsts.COLLECTABLE))
        {
            Debug.Log("collectable");
        }
    }
}