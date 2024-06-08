using System;
using System.Collections.Generic;
using Scritps;
using UnityEngine;

namespace Common
{
    public class JsonHelper
    {
        public List<GameData> gameDatas;

        public JsonHelper(List<GameData> gameDatas)
        {
            this.gameDatas = gameDatas;
        }
    }
        
    [Serializable]
    public class GameData
    {
        public Vector3 position;
        public Enums.ObjectType type;
        public StatsBase stats;

        public GameData(Vector3 position, Enums.ObjectType type)
        {
            this.position = position;
            this.type = type;
        }
        public GameData(Vector3 position, Enums.ObjectType type, StatsBase stats)
        {
            this.position = position;
            this.type = type;
            this.stats = stats;
        }
    }
}