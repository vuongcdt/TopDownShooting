using System;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Collectable : MonoBehaviour
    {
        private static readonly int SPEED_COLLECTABLE = 5;
        private Rigidbody2D _rigidbody2D;

        public static void MoveToPlayer(Vector2 positionPlayer, Transform transform)
        {
            var velocity = Utils.GetVelocity(positionPlayer,transform.position,  SPEED_COLLECTABLE);
            var rg2 = transform.GetComponent<Rigidbody2D>();
            
            rg2.velocity = velocity;
        }

        private void Start()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.Tags.PLAYER))
            {
                gameObject.SetActive(false);
                _rigidbody2D.velocity = Vector2.zero;
                SetPointPlayer();
            }
        }

        private void SetPointPlayer()
        {
            //TODO
        }
    }
}