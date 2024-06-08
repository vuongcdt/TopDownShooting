using Common;
using UnityEngine;

namespace Scritps
{
    public class CollectableManage : Singleton<CollectableManage>
    {
        [SerializeField] private CollectableItem[] collectableItems;
        public void OnSpawn(Vector2 position)
        {
            var randomValue = Random.value;

            foreach (var collectable in collectableItems)
            {
                if(collectable.spawnRate < randomValue)
                {
                    continue;
                }
                
                // Utils.Instantiate(collectable.CollectablePrefab, position, _collectables);
                var collectableGameObject = Utils.Instantiate(collectable.collectablePrefab, position);
                // collectableGameObject.ReBorn();
                return;
            }
        }
    }
}