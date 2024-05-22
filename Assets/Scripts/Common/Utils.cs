using System.Collections.Generic;
using Scritps;
using UnityEngine;
using Object = UnityEngine.Object;

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
        
        public static T Instantiate<T>(T obj, Vector2 spawnPoint, List<T> objList) where T : MyMonoBehaviour
        {
            var objectUnavailable = objList.Find(e => !e.isActiveAndEnabled && e.ObjectType == obj.ObjectType);

            if (!objectUnavailable)
            {
                var newObject = Object.Instantiate(obj, spawnPoint, Quaternion.identity);
                // newObject.ReBorn();
                objList.Add(newObject);
                return newObject;
            }                

            objectUnavailable.gameObject.SetActive(true);
            objectUnavailable.transform.position = spawnPoint;
            return objectUnavailable;
        } 
        
        public static void HiddenGameObject(this GameObject objectGame) 
        {
            objectGame.SetActive(false);
        }      
        
        public static float GetUpgradeFormula(int level)
        {
            return (level / 2 - 0.5f) * 0.5f;
        }
    }
}