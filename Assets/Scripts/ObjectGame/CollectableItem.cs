using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    [System.Serializable]
    public class CollectableItem
    {
        [FormerlySerializedAs("SpawnRate")] [Range(0f, 1f)] public float spawnRate;
        [FormerlySerializedAs("CollectablePrefab")] public Collectable collectablePrefab;
    }
}