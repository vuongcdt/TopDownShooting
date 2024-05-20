using UnityEngine;

namespace Scritps
{
    public class GameManage : Singleton<GameManage>
    {
        [SerializeField] private GameObject player;
        public GameObject Player => player;

        protected override void Awake()
        {
            MakeSingleton(false);
        }
    }
}