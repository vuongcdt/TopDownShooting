using System;
using UnityEngine;

namespace Scritps
{
    public class MuzzleFlash : GameObjectBase
    {
        [Header("MuzzleFlash Settings")]
        [SerializeField] private float timeShooting = 0.1f;

        public void Show()
        {
            gameObject.SetActive(true);
            this.OnDespawn(timeShooting);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}