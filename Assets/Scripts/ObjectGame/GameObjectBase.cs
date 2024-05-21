using Common;
using UnityEngine;

namespace Scritps
{
    public class GameObjectBase : MonoBehaviour
    {
        [SerializeField] private Enums.ObjectType objectType;

        public Enums.ObjectType ObjectType => objectType;
    }
}