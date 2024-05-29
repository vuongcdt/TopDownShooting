using UnityEngine;

namespace Scritps
{
    public class MuzzleFlash : MonoBehaviour
    {
        [Header("MuzzleFlash Settings")]
        [SerializeField] private float timeShooting = 0.1f;

        public void Show()
        {
            gameObject.SetActive(true);
        }

    }
}