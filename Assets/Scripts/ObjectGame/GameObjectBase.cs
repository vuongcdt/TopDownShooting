using System;
using System.Collections;
using Common;
using UnityEngine;

namespace Scritps
{
    public abstract class GameObjectBase : MonoBehaviour
    {
        [Header("Base Settings")] 
        [SerializeField] private bool isAutoDespawn;
        [SerializeField] 
        [ShowIf(ActionOnConditionFail.JustDisable, ConditionOperator.And, nameof(isAutoDespawn))]
        protected float delayTimeDespawn;

        public virtual void OnEnable()
        {
            AutoDespawn();
        } 

        private void AutoDespawn()
        {
            if (!isAutoDespawn || !gameObject.activeSelf)
            {
                return;
            }

            if (delayTimeDespawn > 0)
            {
                OnDespawn(delayTimeDespawn);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        protected void OnDespawn(float delayTime)
        {
            if (delayTime > 0)
            {
                StartCoroutine(IEDelayDespawn(()=> Utils.OnDespawn(this),delayTime));
            }
            else
            {
                Utils.OnDespawn(this);
            }
        }

        private static IEnumerator IEDelayDespawn(Action action,float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            action();
        }
    }
}