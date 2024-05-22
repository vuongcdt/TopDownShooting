using System;
using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Collectable : MyMonoBehaviour
    {
        [SerializeField] private float timeHidden = 30;
        [SerializeField] private float endTimeHidden = 5;

        private Animator _animatorCollectable;
        private static readonly int SPEED_COLLECTABLE = 5;
        private Rigidbody2D _rigidbody2D;

        public static void MoveToPlayer(Vector2 positionPlayer, Collider2D collider)
        {
            var positionCollectable = collider.transform.position;

            var velocity = Utils.GetVelocity(positionPlayer, positionCollectable, SPEED_COLLECTABLE);

            collider.attachedRigidbody.velocity = velocity;
        }

        public void ReBorn()
        {
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLIP);

            HiddenGameObjectWaitForSeconds(timeHidden);
            StartCoroutine(EndTimeHiddenCollectable());
        }

        private IEnumerator EndTimeHiddenCollectable()
        {
            yield return new WaitForSeconds(timeHidden - endTimeHidden);
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLASH);
        }

        private void Awake()
        {
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

            gameObject.HiddenGameObject();
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