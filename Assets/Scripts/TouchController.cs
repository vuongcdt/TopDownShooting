using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace Scritps
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] private float threshHold = 0.2f;
        [SerializeField] private float velocityPlayer = 0.2f;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject anim;
        private Rigidbody2D _rigidbody2DAnim;
        [FormerlySerializedAs("velcityLimit")] [SerializeField] private int velocityLimit = 2;

        private float _timeHold;

        private void Start()
        {
            _rigidbody2DAnim = anim.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
            }

            if (Input.GetMouseButtonUp(0))
            {
                _timeHold = 0;
                _rigidbody2DAnim.velocity = Vector2.zero;
            }

            if (!Input.GetMouseButton(0)) return;

            _timeHold += Time.deltaTime;
            if (_timeHold >= threshHold)
            {
                var mousePos = Input.mousePosition;
                var worldPos = mainCamera.ScreenToWorldPoint(mousePos);

                var position = anim.transform.position;

                var velocity = (Vector2)worldPos - (Vector2)position;

                velocity.x = Mathf.Clamp(velocity.x, -velocityLimit, velocityLimit);
                velocity.y = Mathf.Clamp(velocity.y, -velocityLimit, velocityLimit);

                _rigidbody2DAnim.velocity = new Vector2(velocity.x, velocity.y);

                Debug.Log($"_rigidbody2DAnim.velocity: {_rigidbody2DAnim.velocity}");
            }
        }
    }
}