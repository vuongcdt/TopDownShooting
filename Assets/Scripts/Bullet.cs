using Common;
using UnityEngine;

namespace Scritps
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speedBullet = 20;
        
        private void Start()
        {
            var rotationBullet = gameObject.transform.rotation;
      
            Vector2 velocity = MathHelpers.QuaternionToVector2(rotationBullet);
            
            var rg2 = gameObject.GetComponent<Rigidbody2D>();
            
            rg2.velocity = velocity * speedBullet;

            Invoke(nameof(DestroyBullet), 2);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.Tags.ENEMY))
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