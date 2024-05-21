using Common;
using UnityEngine;

namespace Scritps
{
    public class ObjectBase : MonoBehaviour
    {
        [SerializeField] private Enums.ObjectType objectType;

        public Enums.ObjectType ObjectType => objectType;
    }
}