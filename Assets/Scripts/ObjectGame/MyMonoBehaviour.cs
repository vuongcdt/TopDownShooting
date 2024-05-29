using System.Collections;
using Common;
using UnityEngine;

namespace Scritps
{
    public abstract class MyMonoBehaviour : MonoBehaviour
    {
        [Header("Base Settings")] 
        [SerializeField] private Enums.ObjectType objectType;
        [SerializeField] private bool isAutoHiddenObject;
        [ShowIf(ActionOnConditionFail.JustDisable, ConditionOperator.And, nameof(isAutoHiddenObject))]
        [SerializeField] protected float timeDelayHiddenObject;

        public Enums.ObjectType ObjectType => objectType;

        public virtual void OnEnable()
        {
            AutoHiddenGameObject();
        } 
        public virtual void Awake()
        {
            AutoHiddenGameObject();
        }

        private void AutoHiddenGameObject()
        {
            if (!isAutoHiddenObject || !gameObject.activeSelf)
            {
                return;
            }

            if (timeDelayHiddenObject > 0)
            {
                HiddenGameObjectWaitForSeconds(timeDelayHiddenObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        protected void HiddenGameObjectWaitForSeconds(float time)
        {
            StartCoroutine(DelayHiddenGameObject(time));
        }
     

        private IEnumerator DelayHiddenGameObject(float time)
        {
            yield return new WaitForSeconds(time);
            HiddenGameObject();
        }
        protected void HiddenGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}