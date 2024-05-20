using System.Collections.Generic;
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
            Vector2 velocity = positionFirst - positionLast;

            velocity.Normalize();
            velocity *= velocityScale;

            return velocity;
        }

        public static T Instantiate<T>(T obj, Vector2 spawnPoint, List<T> objList) where T : MonoBehaviour
        {
            var objectUnavailable = objList.Find(e => !e.isActiveAndEnabled);

            if (!objectUnavailable)
            {
                var objectIns = Object.Instantiate(obj, spawnPoint, Quaternion.identity);
                objList.Add(objectIns);
                return objectIns;
            }

            objectUnavailable.gameObject.SetActive(true);
            objectUnavailable.transform.position = spawnPoint;
            return objectUnavailable;
        }
    
        public static float GetUpgradeFormula(int level)
        {
            return (level / 2 - 0.5f) * 0.5f;
        }
    }
}