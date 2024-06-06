using UnityEngine;

namespace Common
{
    public class AutoDeSpawn : MonoBehaviour
    {
        public float delay;

        private void OnEnable()
        {
            Invoke(nameof(DeSpawn), delay);
        }

        private void DeSpawn()
        {
            gameObject.SetActive(false);
        }
    }
}