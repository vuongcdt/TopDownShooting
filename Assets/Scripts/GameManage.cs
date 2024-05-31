using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Scritps
{
    public class GameManage : Singleton<GameManage>
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject coinCollectable;
        [SerializeField] private GameObject diamondCollectable;
        [SerializeField] private GameObject healthCollectable;
        [SerializeField] private GameObject lifeCollectable;
        [SerializeField] private float timeSave = 1;
        
        public GameObject spawnWrap;
        public Enums.GameState gameState;
        public bool isClearData;
        public GameObject Player => player;

        private float _timeCount;

        protected override void Awake()
        {
            MakeSingleton(false);
            
            if (isClearData)
            {
                Prefs.ClearData();
            }
            else
            {
                LoadMap();
            }
        }

        private void FixedUpdate()
        {
            SaveGame();
            CheckGameState();
        }

        private void CheckGameState()
        {
            var isPauseGame = gameState is Enums.GameState.Pause or Enums.GameState.Over;
            Time.timeScale = isPauseGame ? 0 : 1;
        }

        private void SaveGame()
        {
            _timeCount += Time.fixedDeltaTime;
            if (_timeCount < timeSave)
            {
                return;
            }

            _timeCount = 0;
            var gameDatas = Utils.GameObjectsStore
                .Where(e => e.enabled && e.stats is not { type: Enums.ObjectType.Bullet })
                .Select(e => new GameData(e.transform.position, e.stats.type))
                .ToList();

            var jsonHelper = new JsonHelper(gameDatas);

            Prefs.MapData = JsonUtility.ToJson(jsonHelper);
        }

        private void LoadMap()
        {
            JsonHelper jsonHelper = new(new List<GameData>());
            JsonUtility.FromJsonOverwrite(Prefs.MapData, jsonHelper);

            jsonHelper.gameDatas.ForEach(e =>
            {
                Debug.Log(e.type);
            });
            
            jsonHelper.gameDatas.ForEach(e =>
            {
                GameObject objectIns = new();
                switch (e.type)
                {
                    case Enums.ObjectType.Enemy:
                        objectIns = enemy;
                        break;
                    case Enums.ObjectType.CoinCollectable:
                        break;
                    case Enums.ObjectType.DiamondCollectable:
                        break;
                    case Enums.ObjectType.HealthPotionCollectable:
                        break;
                    case Enums.ObjectType.LifeCollectable:
                        break;
                }

                Instantiate(objectIns, e.position, Quaternion.identity);
            });
        }
    }
}