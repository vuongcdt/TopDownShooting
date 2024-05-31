using System;
using Scritps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerCollectable;
    [SerializeField] private float collectableDectionRadius = 1;
    [SerializeField] private PlayerStats playerStats;
    
    public void TakeDamage(float damage)
    {
        playerStats.hp -= damage;
    }
    
    private void Awake()
    {
        GetPositionPlayer();
    }

    private void GetPositionPlayer()
    {
        // if (GameManage.Ins.isClearData)
        // {
        //     Prefs.ClearData();
        // }

        transform.position = playerStats.position;
        // transform.position = GameManage.Ins.isClearData ? Vector3.zero : playerStats.position;
    }

    private void FixedUpdate()
    { 
        playerStats.position = transform.position;
        FindCollectable();
    }

    private void FindCollectable()
    {
        var positionPlayer = gameObject.transform.position;
        var col2DCollectables = Physics2D.OverlapCircleAll(positionPlayer, collectableDectionRadius, layerCollectable);

        foreach (var collider2d in col2DCollectables)
        {
            Collectable.MoveToPlayer(positionPlayer,collider2d);       
        }
    }
}