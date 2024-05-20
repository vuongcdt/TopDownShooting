using System;
using UnityEngine;

namespace Scritps
{
    public class MuzzleFlash : MonoBehaviour
    {
        [SerializeField] private float timeShooting = 0.1f;

        public void Show()
        {
            gameObject.SetActive(true);
            Invoke(nameof(HiddenMuzzle), timeShooting);
        }

        private void Start()
        {
            HiddenMuzzle();
        }

        private void HiddenMuzzle()
        {
            gameObject.SetActive(false);
        }
    }
}