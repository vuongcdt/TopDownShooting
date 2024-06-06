using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private bool isClearData;

        public int CountEnemy
        {
            get => _countEnemy;
            set => _countEnemy = value;
        }

        public GameObject Player => player;

        private float _timeCount;
        private bool _isSave;
        private int _countEnemy;

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

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

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveGame();
            }

            if (!pauseStatus)
            {
                _isSave = false;
            }
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                SaveGame();
            }

            if (hasFocus)
            {
                _isSave = false;
            }
        }

        private void SaveGame()
        {
            if (_isSave) return;
            _isSave = true;

            var gameDatas = Utils.GameObjectsStore
                .Where(e => e.enabled && e.stats is not { type: Enums.ObjectType.Bullet })
                // .Select(e => new GameData(e.transform.position, e.stats.type))
                .Select(e => new GameData(e.transform.position, e.stats.type, JsonUtility.ToJson(e.stats)))
                .ToList();

            var jsonHelper = new JsonHelper(gameDatas);

            Prefs.MapData = JsonUtility.ToJson(jsonHelper);
        }

        private void LoadMap()
        {
            Debug.Log("LoadMap");
            JsonHelper jsonHelper = new(new List<GameData>());
            JsonUtility.FromJsonOverwrite(Prefs.MapData, jsonHelper);

            // Debug.Log("1111111111: " + jsonHelper.gameDatas.Count);
            // jsonHelper.gameDatas.ForEach(e =>
            // {
            //     Debug.Log(e.stats);
            // });
            
            GameObject objectIns = new();
            string str = null;
            jsonHelper.gameDatas.ForEach(e =>
            {
                switch (e.type)
                {
                    case Enums.ObjectType.Enemy:
                        objectIns = enemy;
                        str = e.stats;
                        JsonUtility.FromJsonOverwrite(e.stats,objectIns.GetComponent<Enemy>().stats);
                        break;
                    case Enums.ObjectType.CoinCollectable:
                        objectIns = coinCollectable;
                        // JsonUtility.FromJsonOverwrite(e.stats, (CoinStats)objectIns.GetComponent<Collectable>().stats);
                        break;
                    case Enums.ObjectType.DiamondCollectable:
                        objectIns = diamondCollectable;
                        // JsonUtility.FromJsonOverwrite(e.stats, (DiamondStats)objectIns.GetComponent<Collectable>().stats);
                        break;
                    case Enums.ObjectType.HealthPotionCollectable:
                        objectIns = healthCollectable;
                        // JsonUtility.FromJsonOverwrite(e.stats, (HealthStats)objectIns.GetComponent<Collectable>().stats);
                        break;
                    case Enums.ObjectType.LifeCollectable:
                        objectIns = lifeCollectable;
                        // JsonUtility.FromJsonOverwrite(e.stats, (LifeStats)objectIns.GetComponent<Collectable>().stats);
                        break;
                    // case Enums.ObjectType.None:
                    // case Enums.ObjectType.Player:
                    // case Enums.ObjectType.Bullet:
                    //     objectIns = bullet;
                    //     break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Instantiate(objectIns, e.position, Quaternion.identity);
            });
            Debug.Log( "}}}}}}}}}" + str);
        }
    }
}