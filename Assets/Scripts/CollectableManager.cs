using Common;
using ObjectGame;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    [SerializeField] private CollectableItem[] collectableItems;
    public void OnSpawn(Vector2 position,int levelEnemy)
    {
        var randomValue = Random.value;

        foreach (var collectable in collectableItems)
        {
            if(collectable.spawnRate < randomValue)
            {
                continue;
            }
            
            collectable.collectablePrefab.stats.level = levelEnemy;
            Utils.Instantiate(collectable.collectablePrefab, position);
            
            return;
        }
    }
}