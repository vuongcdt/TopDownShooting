using System;
using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Collectable : MyMonoBehaviour
    {
        [Header("Collectable Settings")]
        [SerializeField] private float endTimeHidden = 5f;

        private Animator _animatorCollectable;
        private static readonly int SPEED_COLLECTABLE = 5;
        private Rigidbody2D _rigidbody2D;
        
        public override void OnEnable()
        {
            base.OnEnable();
            ReBorn();
        }

        public static void MoveToPlayer(Vector2 positionPlayer, Collider2D collider)
        {
            var positionCollectable = collider.transform.position;

            var velocity = Utils.GetVelocity(positionPlayer, positionCollectable, SPEED_COLLECTABLE);

            collider.attachedRigidbody.velocity = velocity;
        }

        private void ReBorn()
        {
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLIP);

            HiddenGameObjectWaitForSeconds(timeDelayHiddenObject);
            StartCoroutine(EndTimeHiddenCollectable());
        }

        private IEnumerator EndTimeHiddenCollectable()
        {
            yield return new WaitForSeconds(timeDelayHiddenObject - endTimeHidden);
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLASH);
        }

        public override void Awake()
        {
            base.Awake();
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animatorCollectable = gameObject.GetComponent<Animator>();
            ReBorn();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Constants.TagsConsts.PLAYER))
            {
                return;
            }

            // gameObject.HiddenGameObject();
            HiddenGameObject();
            _rigidbody2D.velocity = Vector2.zero;
            SetPointPlayer();
        }

        private void SetPointPlayer()
        {
            //TODO
            // Prefs.PlayerData;
        }
    }
}