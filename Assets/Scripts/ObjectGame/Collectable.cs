using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class Collectable : GameObjectBase
    {
        [SerializeField] private float timeHidden = 30;
        [SerializeField] private float endTimeHidden = 5;
        
        private Animator _animatorCollectable;
        private static readonly int SPEED_COLLECTABLE = 5;
        private Rigidbody2D _rigidbody2D;

        public static void MoveToPlayer(Vector2 positionPlayer, Transform transform)
        {
            var velocity = Utils.GetVelocity(positionPlayer,transform.position,  SPEED_COLLECTABLE);
            var rg2 = transform.GetComponent<Rigidbody2D>();
            
            rg2.velocity = velocity;
        }
        
        public void AutoHiddenByTime()
        {
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLIP);
            Invoke(nameof(HiddenCollectable),timeHidden );
            Invoke(nameof(EndTimeHiddenCollectable),timeHidden - endTimeHidden);
        }

        private void EndTimeHiddenCollectable()
        {
            _animatorCollectable.SetTrigger(Constants.AnimatorConsts.FLASH);
        }

        private void HiddenCollectable()
        {
            gameObject.HiddenGameObject();
        }

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animatorCollectable = gameObject.GetComponent<Animator>();
            AutoHiddenByTime();
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
        }
    }
}