using System;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Bullet : MonoBehaviour
    {
        private void Start()
        {
            var rotationBullet = gameObject.transform.rotation;
      
            Vector2 velocity = rotationBullet * Vector3.right;
            // Debug.Log($"degW: {degW}");
            
            var rg2 = gameObject.GetComponent<Rigidbody2D>();
            rg2.velocity = velocity;

            Invoke(nameof(DestroyBullet), 2);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constans.Tags.Enemy))
            {
                DestroyBullet();
            }
        }
        
        private void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}