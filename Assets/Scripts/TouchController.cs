using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scritps
{
    public class TouchController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Animator animatorPlayer;
        [SerializeField] private Player player;
        [SerializeField] private Rigidbody2D rigidbody2DPlayer;

        private static readonly int RUN_ANIMATOR = Animator.StringToHash(Constants.AnimatorConsts.RUN);
        private static readonly int IDLE_ANIMATOR = Animator.StringToHash(Constants.AnimatorConsts.IDLE);

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                rigidbody2DPlayer.velocity = Vector2.zero;

                animatorPlayer.ResetTrigger(RUN_ANIMATOR);
                animatorPlayer.SetTrigger(IDLE_ANIMATOR);
            }

            if (!Input.GetMouseButton(0)) return;

            MoveToMousePoint();
        }

        private void MoveToMousePoint()
        {
            animatorPlayer.SetTrigger(RUN_ANIMATOR);
            var positionAnimator = animatorPlayer.transform.position;

            var mousePosition = Input.mousePosition;
            var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            var velocity = Utils.GetVelocity(worldPosition, positionAnimator, player.PlayerStats.moveSpeed);

            animatorPlayer.transform.rotation = Utils.GetFlipAmation(velocity);
            rigidbody2DPlayer.velocity = velocity;
        }
    }
}