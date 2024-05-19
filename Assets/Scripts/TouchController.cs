using Common;
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
        private static readonly int RUN = Animator.StringToHash(Constants.Animator.RUN);
        private static readonly int IDLE = Animator.StringToHash(Constants.Animator.IDLE);

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
                _animatorPlayer.ResetTrigger(RUN);
                _animatorPlayer.SetTrigger(IDLE);
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
            _animatorPlayer.SetTrigger(RUN);
            var positionAnimator = animatorPlayer.transform.position;

            var mousePosition = Input.mousePosition;
            var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            var velocity = Utils.GetVelocity(worldPosition, positionAnimator, velocityLimit);

            _animatorPlayer.transform.localScale = Utils.SetFlipAmation(velocity);
            _rigidbody2DPlayer.velocity = velocity;
        }
    }
}