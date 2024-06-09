using System;
using System.Collections.Generic;
using System.Linq;
using ObjectGame;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    public static class Utils
    {
        private static List<GameObjectBase> _gameObjectsDespawn = new();

        private static List<GameObjectBase> _gameObjectsStore = new();
        public static List<GameObjectBase> GameObjectsStore => _gameObjectsStore;

        public static Quaternion GetFlipAmation(Vector2 velocity)
        {
            var postion = new Vector3(0, velocity.x < 0 ? 180 : 0);
            return Quaternion.Euler(postion);
        }

        public static Vector2 GetVelocity(Vector3 positionFirst, Vector3 positionLast, float velocityScale)
        {
            Vector2 velocity = positionFirst - positionLast;

            velocity.Normalize();
            velocity *= velocityScale;

            return velocity;
        }

        public static T Instantiate<T>(T obj, Vector2 spawnPoint) where T : GameObjectBase
        {
            var objectDespawn =
                _gameObjectsDespawn.FirstOrDefault(e => !e.gameObject.activeSelf && e.name.Contains(obj.name));

            if (!objectDespawn)
            {
                var newObject = Object.Instantiate(obj, spawnPoint, Quaternion.identity);
                _gameObjectsStore.Add(newObject);
                return newObject;
            }

            objectDespawn.gameObject.SetActive(true);
            objectDespawn.transform.position = spawnPoint;
            return objectDespawn as T;
        }

        public static void OnDespawn(GameObjectBase gameObject)
        {
            gameObject.gameObject.SetActive(false);
            _gameObjectsDespawn.Add(gameObject);
        }

        public static float GetUpgradeFormula(int level)
        {
            return level / 4f + 1;
        }
    }
}