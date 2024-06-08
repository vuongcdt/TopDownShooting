using Common;
using UnityEngine;

namespace Scritps
{
    public class GameStats:Singleton<GameStats>
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private EnemyStats enemyStats;
        [SerializeField] private BulletStats bulletStats;
        [SerializeField] private CoinStats coinStats;
        [SerializeField] private DiamondStats diamondStats;
        [SerializeField] private HealthStats healthStats;
        [SerializeField] private LifeStats lifeStats;
        [SerializeField] private GunStats gunStats;

        public PlayerStats PlayerStats
        {
            get => playerStats;
            set => playerStats = value;
        }

        public EnemyStats EnemyStats
        {
            get => enemyStats;
            set => enemyStats = value;
        }

        public BulletStats BulletStats
        {
            get => bulletStats;
            set => bulletStats = value;
        }

        public CoinStats CoinStats
        {
            get => coinStats;
            set => coinStats = value;
        }

        public DiamondStats DiamondStats
        {
            get => diamondStats;
            set => diamondStats = value;
        }

        public HealthStats HealthStats
        {
            get => healthStats;
            set => healthStats = value;
        }

        public LifeStats LifeStats
        {
            get => lifeStats;
            set => lifeStats = value;
        }

        public GunStats GunStats
        {
            get => gunStats;
            set => gunStats = value;
        }
    }
}