using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace Scritps
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] private float threshHold = 0.2f;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject anim;
        [SerializeField] private int velocityLimit = 2;

        private Rigidbody2D _rigidbody2DAnim;
        private Animator _animator;
        private float _timeHold;
        private static readonly int Run = Animator.StringToHash("run");

        private void Start()
        {
            _rigidbody2DAnim = anim.GetComponent<Rigidbody2D>();
            _animator = anim.GetComponent<Animator>();
            Debug.Log(Run);
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _timeHold = 0;
                _rigidbody2DAnim.velocity = Vector2.zero;
            }

            if (!Input.GetMouseButton(0)) return;

            _timeHold += Time.deltaTime;
            if (_timeHold >= threshHold)
            {
                _animator.SetTrigger(Run);
                var positionAnim = anim.transform.position;

                var mousePos = Input.mousePosition;
                var worldPos = mainCamera.ScreenToWorldPoint(mousePos);
                var distanceToMouse = Vector2.Distance(worldPos, positionAnim);

                var scaleVelocity = distanceToMouse > 0.2 ? velocityLimit / distanceToMouse : 1;
                
                Vector2 velocity = (worldPos - positionAnim) * scaleVelocity;

                velocity.x = Mathf.Clamp(velocity.x, -velocityLimit, velocityLimit);
                velocity.y = Mathf.Clamp(velocity.y, -velocityLimit, velocityLimit);

                _rigidbody2DAnim.velocity = velocity;

                Debug.Log($"diatanceToMouse: {distanceToMouse}");
                Debug.Log($"_rigidbody2DAnim.velocity: {_rigidbody2DAnim.velocity}");
            }
        }
    }
}