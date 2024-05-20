using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class CollectableManage : Singleton<CollectableManage>
    {
        [SerializeField] private CollectableItem[] collectableItems;
        private List<Collectable> _collectables = new();
        public void Spawn(Vector2 position)
        {
            var randomValue = Random.value;

            foreach (var collectable in collectableItems)
            {
                if(collectable.SpawnRate < randomValue)
                {
                    continue;
                }
                
                // Instantiate(collectable.CollectablePrefab, position, Quaternion.identity);
                Utils.Instantiate(collectable.CollectablePrefab, position, _collectables);
                return;
            }
        }
    }
}