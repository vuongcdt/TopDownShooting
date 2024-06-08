using System;
using Common;
using Scritps;
using Scritps.GUI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public void AddXp(int value)
    {
        playerStats.xp += value;
        UIManage.Ins.SetLevelBar(playerStats);
    }

    public void AddHp(int value)
    {
        playerStats.hp += value;
    }
    public void TakeDamage(float damage)
    {
        playerStats.hp -= damage;
        UIManage.Ins.SetHpBar(playerStats);
    }

    public PlayerStats PlayerStats
    {
        get => playerStats;
        set => playerStats = value;
    }

    private void Awake()
    {
        GetPositionPlayer();
    }

    private void GetPositionPlayer()
    {
        transform.position = !GameManage.Ins.isClearData ? playerStats.position : Vector3.zero;
    }

    private void FixedUpdate()
    {
        playerStats.position = transform.position;

        if (playerStats.hp < 0)
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