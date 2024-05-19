using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scritps
{
    public class Map:MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private Transform spawnPoint;

        private float _countTime;
        private List<Enemy> _enemies = new List<Enemy>();
        private void Update()
        {
            _countTime += Time.deltaTime;
            
            if(_enemies.Count > 10 )
            {
                return;
            }
            
            if (_countTime > 1)
            {
                SpawnEnemy();
                _countTime = 0;
            }
        }

        private void SpawnEnemy()
        {
            var enemyGameObject = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            _enemies.Add(enemyGameObject);
        }
    }
}