using UnityEngine;

namespace Scritps
{
    [CreateAssetMenu(fileName = "EnemyStats",menuName = "Create Stats/Create Enemy Stats")]
    public class EnemyStats: ActorStats
    {
        [field: Header("Xp Bonus:")] 
        public float MinXpBonus { get; set; }
        public float MaxXpBonus { get; set; }
        
        [field: Header("Level Up:")] 
        public float DamageUp { get; set; }
        public float HpUp { get; set; }
    }
}