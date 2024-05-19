using UnityEngine;

namespace Scritps
{
    public class GameManage : Singleton<GameManage>
    {
        [SerializeField] private GameObject player;
        public GameObject Player => player;
        // public Player Player
        // {
        //     get => player;
        //     private set => player = value;
        // }

        protected override void Awake()
        {
            MakeSingleton(false);
        }
    }
}