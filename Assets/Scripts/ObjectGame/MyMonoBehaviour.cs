using System;
using System.Collections;
using Common;
using JetBrains.Annotations;
using UnityEngine;

namespace Scritps
{
    public abstract class MyMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private Enums.ObjectType objectType;

        public Enums.ObjectType ObjectType => objectType;

        // public abstract void ReBorn();

        // protected IEnumerator  ActionWaitForSeconds(Action onAction, float time)
        // {
        //     yield return StartCoroutine(ActionDelay(time));
        //     onAction();
        // }

        protected void HiddenGameObjectWaitForSeconds(float time)
        {
            StartCoroutine(ActionDelay(time));
        }

        protected void HiddenGameObjectWaitForSeconds(float time, [CanBeNull] GameObject gameObj )
        {
            StartCoroutine(ActionDelay(time,gameObj));
        }

        private IEnumerator ActionDelay(float time, GameObject gameObj = null)
        {
            yield return new WaitForSeconds(time);
            if (gameObj)
            {
                gameObj.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}