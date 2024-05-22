using System.Collections;
using UnityEngine;

namespace Scritps
{
    public class MuzzleFlash : MyMonoBehaviour
    {
        [SerializeField] private float timeShooting = 0.1f;

        public void Show()
        {
            gameObject.SetActive(true);
            HiddenGameObjectWaitForSeconds(timeShooting);
        }

        private void Start()
        {
            HiddenGameObjectWaitForSeconds(timeShooting);
        }
    }
}