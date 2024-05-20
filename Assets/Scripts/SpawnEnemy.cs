using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scritps
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private float timeSpawn = 0.5f;
        [SerializeField] private float enemiesLimit = 20;
        [SerializeField] private Transform[] spawnPoints;
        private float _timeSpawn;

        private readonly List<Enemy> _enemies = new();

        private void Update()
        {
            _timeSpawn += Time.deltaTime;

            var isLimitEnemies = _enemies.Count(e => e.gameObject.activeSelf) > enemiesLimit;

            if (isLimitEnemies)
            {
                return;
            }

            if (_timeSpawn > timeSpawn)
            {
                SpawnEnemyByPoint();
                _timeSpawn = 0;
            }
        }

        private void SpawnEnemyByPoint()
        {
            var random = Random.Range(0, spawnPoints.Length);
            var spawnPoint = spawnPoints[random].position;

            var enemyIns = Utils.Instantiate(enemy, spawnPoint, _enemies);
            enemyIns.ReBorn();
        }
    }
}