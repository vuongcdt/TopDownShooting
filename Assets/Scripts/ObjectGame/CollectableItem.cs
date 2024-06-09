using UnityEngine;

namespace ObjectGame
{
    [System.Serializable]
    public class CollectableItem
    {
        [Range(0f, 1f)] public float spawnRate;
        public Collectable collectablePrefab;
    }
}