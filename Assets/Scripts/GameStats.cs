using Stats;
using UnityEngine;

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

    public PlayerStats PlayerStats => playerStats;

    public EnemyStats EnemyStats => enemyStats;

    public BulletStats BulletStats => bulletStats;

    public CoinStats CoinStats => coinStats;

    public DiamondStats DiamondStats => diamondStats;

    public HealthStats HealthStats => healthStats;

    public LifeStats LifeStats => lifeStats;

    public GunStats GunStats => gunStats;
}