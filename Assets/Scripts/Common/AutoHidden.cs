using UnityEngine;

namespace Common
{
    public class AutoHidden : MonoBehaviour
    {
        public float delay;

        private void OnEnable()
        {
            Invoke(nameof(HiddenObjectGame), delay);
        }

        private void HiddenObjectGame()
        {
            gameObject.SetActive(false);
        }
    }
}