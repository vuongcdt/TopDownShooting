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
            var spawnPoint = GetRandomSpawnPoint();
            
            var enemyIns =  Utils.SetActiveObject(enemy,spawnPoint,_enemies);
            enemyIns.ReBorn();
            
            // var enemyUnavailable = _enemies.Find(e => !e.isActiveAndEnabled);
            //
            // if (!enemyUnavailable)
            // {
            //     var enemyIns = Instantiate(enemy, spawnPoint, Quaternion.identity);
            //     _enemies.Add(enemyIns);
            // }
            // else
            // {
            //     enemyUnavailable.gameObject.SetActive(true);
            //     enemyUnavailable.transform.position = spawnPoint;
            // }
        }

        private Vector3 GetRandomSpawnPoint()
        {
            var random = Random.Range(0, spawnPoints.Length);
            return spawnPoints[random].position;
        }
    }
}