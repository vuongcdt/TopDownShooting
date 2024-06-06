using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Collectable : GameObjectBase
    {
        [Header("Collectable Settings")] [SerializeField]
        private float endTimeDespawn = 5f;

        private Animator _animatorCollectable;
        private Rigidbody2D _rigidbody2D;
        private static readonly int SPEED_COLLECTABLE = 5;

        public override void OnEnable()
        {
            base.OnEnable();
            OnInit();
        }
        // public static void MoveToPlayer(Vector2 positionPlayer, Collider2D collider)
        // {
        //     var positionCollectable = collider.transform.position;
        //
        //     // var velocity = Utils.GetVelocity(positionPlayer, positionCollectable, SPEED_COLLECTABLE);
        //
        //     // collider.attachedRigidbody.velocity = velocity;
        //     collider.transform.position = Vector3
        //         .MoveTowards(positionCollectable, positionPlayer, SPEED_COLLECTABLE * Time.fixedTime);
        // }

        private void OnInit()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animatorCollectable = gameObject.GetComponent<Animator>();
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLIP);
            StartCoroutine(EndTimeHiddenCollectable());
        }


        private IEnumerator EndTimeHiddenCollectable()
        {
            yield return new WaitForSeconds(delayTimeDespawn - endTimeDespawn);
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLASH);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Constants.TagsConsts.PLAYER))
            {
                this.OnDespawn(0f);
                _rigidbody2D.velocity = Vector2.zero;
            }
        }
    }
}