using System;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speedBullet = 30;

        private Rigidbody2D _rigidbody2D;

        public void WakeUp(Vector2 positionTarget)
        {
            var positionBullet = gameObject.transform.position;
            var velocity = Utils.GetVelocity(positionTarget, positionBullet, speedBullet);

            Quaternion transformRotation = MathHelpers.Vector2ToQuaternion(velocity);
            gameObject.transform.rotation = transformRotation;

            _rigidbody2D.velocity = velocity;
        }

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.Tags.ENEMY))
            {
                gameObject.SetActive(false);
            }
        }
    }
}