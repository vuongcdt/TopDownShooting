using UnityEngine;

namespace Scritps
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] private float threshHold = 0.2f;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject animatorPlayer;
        [SerializeField] private GameObject player;
        [SerializeField] private int velocityLimit = 2;

        private Rigidbody2D _rigidbody2DPlayer;
        private Animator _animatorPlayer;
        private float _timeHold;
        private static readonly int Run = Animator.StringToHash("run");
        private static readonly int Idle = Animator.StringToHash("idle");

        private void Start()
        {
            _rigidbody2DPlayer = player.GetComponent<Rigidbody2D>();
            _animatorPlayer = animatorPlayer.GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _timeHold = 0;
                _rigidbody2DPlayer.velocity = Vector2.zero;
                _animatorPlayer.ResetTrigger(Run);
                _animatorPlayer.SetTrigger(Idle);
            }

            if (!Input.GetMouseButton(0)) return;

            _timeHold += Time.deltaTime;

            if (_timeHold >= threshHold)
            {
                MoveToMousePoint();
            }
        }

        private void MoveToMousePoint()
        {
            _animatorPlayer.SetTrigger(Run);
            var positionAnimator = animatorPlayer.transform.position;

            var mousePosition = Input.mousePosition;
            var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            var velocity = GetVelocity(worldPosition, positionAnimator, velocityLimit);

            _animatorPlayer.transform.localScale = SetFlipAmation(velocity);
            _rigidbody2DPlayer.velocity = velocity;
        }

        public static Vector3 SetFlipAmation(Vector2 velocity)
        {
            return velocity.x < 0 ? new Vector3(-1, 1) : new Vector3(1, 1);
        }

        public static Vector2 GetVelocity(Vector3 positionFirst, Vector3 positionLast, float velocityLimit)
        {
            var distanceToMousePoint = Vector2.Distance(positionFirst, positionLast);
            
            // var scaleVelocity = distanceToMouse > 0.2 ? velocityLimit / distanceToMouse : 1;
            // Vector2 velocity = (positionFirst - positionLast) * scaleVelocity;
            Vector2 velocity = (positionFirst - positionLast);
            if(distanceToMousePoint > 0.2)
            {
                velocity.Normalize();
            }
            velocity *= velocityLimit;
            
            // velocity.x = Mathf.Clamp(velocity.x, -velocityLimit, velocityLimit);
            // velocity.y = Mathf.Clamp(velocity.y, -velocityLimit, velocityLimit);

            return velocity;
        }
    }
}