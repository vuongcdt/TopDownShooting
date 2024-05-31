namespace Common
{
    public class Enums
    {
        public enum ObjectType
        {
            None,
            Player,
            Enemy ,
            CoinCollectable,
            DiamondCollectable,
            HealthPotionCollectable,
            LifeCollectable,
            Bullet
        } 
        public enum GameState
        {
            Playing,
            Over,
            Pause,
            NewGame
        }
    }
}