﻿using UnityEngine;

namespace Scritps
{
    [System.Serializable]
    public class CollectableItem
    {
        [Range(0f, 1f)] public float SpawnRate;
        public Collectable CollectablePrefab;
    }
}