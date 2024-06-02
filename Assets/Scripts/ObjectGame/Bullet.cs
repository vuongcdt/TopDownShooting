using System;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Bullet : GameObjectBase
    {
        [Header("Bullet Settings")]
        [SerializeField] private float speedBullet = 30;

        private Rigidbody2D _rigidbody2D;

        public void OnInit(Vector2 positionTarget)
        {
            var positionBullet = this.transform.position;
            var velocity = Utils.GetVelocity(positionTarget, positionBullet, speedBullet);

            Quaternion transformRotation = MathHelpers.Vector2ToQuaternion(velocity);
            this.transform.rotation = transformRotation;

            _rigidbody2D.velocity = velocity;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            this.OnDespawn(2f);
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        // private void OnTriggerEnter2D(Collider2D col)
        // {
        //     if (col.CompareTag(Constants.TagsConsts.ENEMY))
        //     {
        //         this.OnDespawn(0f);
        //     }
        // }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (collision2D.gameObject.CompareTag(Constants.TagsConsts.ENEMY))
            {
                this.OnDespawn(0f);
            }
        }
    }
}