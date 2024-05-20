using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "Enemy Stats")]
    public class EnemyStats: ActorStats
    {
        [Header("Xp Bonus:")] 
        public float minXpBonus ;
        public float maxXpBonus ;
        
        [Header("Level Up:")] 
        public float damageUp ;
        public float hpUp ;
    }
}