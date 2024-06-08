using Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scritps
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private float timeSpawn = 1f;
        [SerializeField] private Transform[] spawnPoints;
        
        private float _timeSpawn;

        private void FixedUpdate()
        {
            _timeSpawn += Time.fixedDeltaTime;
            
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

            Utils.Instantiate(enemy, spawnPoint);
        }
    }
}