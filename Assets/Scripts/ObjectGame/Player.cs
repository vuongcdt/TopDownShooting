using Common;
using GUI;
using Stats;
using UnityEngine;

namespace ObjectGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;

        public PlayerStats PlayerStats
        {
            get => playerStats;
            set => playerStats = value;
        }

        private void Awake()
        {
            GetPositionPlayer();
        }

        private void GetPositionPlayer()
        {
            transform.position = !GameManager.Ins.isClearData ? playerStats.position : Vector3.zero;
        }

        private void FixedUpdate()
        {
            playerStats.position = transform.position;

            if (playerStats.hp < 0)
            {
                Time.timeScale = 0;
                Debug.Log("Game over");
            }
        }

        // private void OnTriggerEnter2D(Collider2D col)
        // {
        //     if (col.CompareTag(Constants.TagsConsts.COLLECTABLE))
        //     {
        //         Debug.Log("collectable level" );
        //     }
        // }
    }
}