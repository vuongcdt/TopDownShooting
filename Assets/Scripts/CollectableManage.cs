﻿using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class CollectableManage : Singleton<CollectableManage>
    {
        [SerializeField] private CollectableItem[] collectableItems;
        private readonly List<Collectable> _collectables = new();
        public void Spawn(Vector2 position)
        {
            var randomValue = Random.value;

            foreach (var collectable in collectableItems)
            {
                if(collectable.SpawnRate < randomValue)
                {
                    continue;
                }
                
                Utils.Instantiate(collectable.CollectablePrefab, position, _collectables);
                return;
            }
        }
    }
}