using System.Collections.Generic;
using Scritps;
using UnityEngine;

namespace Common
{
    public static class Utils
    {
        public static Vector3 SetFlipAmation(Vector2 velocity)
        {
            return velocity.x < 0 ? new Vector3(-1, 1) : new Vector3(1, 1);
        }

        public static Vector2 GetVelocity(Vector3 positionFirst, Vector3 positionLast, float velocityScale)
        {
            var distanceToMousePoint = Vector2.Distance(positionFirst, positionLast);

            // var scaleVelocity = distanceToMouse > 0.2 ? velocityLimit / distanceToMouse : 1;
            // Vector2 velocity = (positionFirst - positionLast) * scaleVelocity;
            Vector2 velocity = (positionFirst - positionLast);
            // if(distanceToMousePoint > 0.2)
            // {
            //     velocity.Normalize();
            // }
            velocity.Normalize();

            velocity *= velocityScale;

            // velocity.x = Mathf.Clamp(velocity.x, -velocityLimit, velocityLimit);
            // velocity.y = Mathf.Clamp(velocity.y, -velocityLimit, velocityLimit);

            return velocity;
        }

        public static T SetActiveObject<T>(T enemy, Vector2 spawnPoint, List<T> enemies) where T : MonoBehaviour
        {
            var enemyUnavailable = enemies.Find(e => !e.isActiveAndEnabled);

            if (!enemyUnavailable)
            {
                var enemyIns = Object.Instantiate(enemy, spawnPoint, Quaternion.identity);
                enemies.Add(enemyIns);
                return enemyIns;
            }

            enemyUnavailable.gameObject.SetActive(true);
            enemyUnavailable.transform.position = spawnPoint;
            return enemyUnavailable;
        }
    }
}