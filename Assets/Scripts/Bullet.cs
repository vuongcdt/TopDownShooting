using System;
using UnityEngine;

namespace Scritps
{
    public class Bullet : MonoBehaviour
    {
        private void Start()
        {
            Invoke(nameof(DestroyBullet), 2);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                Debug.Log("bullet va cham enemy");
                DestroyBullet();
            }
        }
        
        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}