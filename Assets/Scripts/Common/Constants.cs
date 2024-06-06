namespace Common
{
    public class Constants
    {
        public class TagsConsts
        {
            public const string ENEMY = "Enemy";
            public const string PLAYER = "Player";
            public const string BULLET = "Bullet";
            public const string COLLECTABLE = "Collectable";
        }  
        public class AnimatorConsts
        {
            public const string IDLE = "idle";
            public const string RUN = "run";
            public const string DEATH = "death";
            public const string FLASH = "flash";
            public const string FLIP = "flip";
        }
        public class PrefConsts
        {
            public const string COIN_DATA_KEY = "CoinData";
            public const string PLAYER_DATA_KEY = "PlayerData";
            public const string ENEMY_DATA_KEY = "EnemyData";
            public const string BULLET_DATA_KEY = "WeaponData";
            public const string MAP_DATA_KEY = "MapData";
        }
        public class LayerConsts
        {
            public const string DEFAULT_LAYER = "Default";
            public const string PLAYER_LAYER = "Player";
            public const string ENEMY_LAYER = "Enemy";
            public const string COLLECTABLE_LAYER = "Collectable";
        }
    }
}