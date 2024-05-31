using System;
using System.Collections;
using Common;
using UnityEngine;

namespace Scritps
{
    [Serializable]
    public abstract class GameObjectBase : MonoBehaviour
    {
        [Header("Base Settings")] [SerializeField]
        private bool isAutoDespawn;

        [ShowIf(ActionOnConditionFail.JustDisable, ConditionOperator.And, nameof(isAutoDespawn))] [SerializeField]
        protected float delayTimeDespawn;

        [SerializeField] public StatsBase stats;

        public virtual void OnEnable()
        {
            // if (stats)
            // {
            //     transform.position = stats.position;
            // }

            AutoDespawn();
        }

        protected virtual void FixedUpdate()
        {

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
                StartCoroutine(IEDelayDespawn(() => Utils.OnDespawn(this), delayTime));
            }
            else
            {
                Utils.OnDespawn(this);
            }
        }

        private static IEnumerator IEDelayDespawn(Action action, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            action();
        }
    }
}