using System.Linq;
using Common;
using Stats;
using UnityEngine;

namespace ObjectGame
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private MuzzleFlash muzzleFlash;
        [SerializeField] private Bullet bullet;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private LayerMask layerEnemy;
        [SerializeField] private GunStats gunStats;

        private float _timeDelayShooting;
        private Component _enemyNearest;

        private void FixedUpdate()
        {
            FindEnemy();
            if (!_enemyNearest)
            {
                this.transform.rotation = Quaternion.identity;
                return;
            }
            AimingTarget();
            Shooting();
        }

        private void FindEnemy()
        {
            var positionWeapon = this.transform.position;
            var findEnemys = Physics2D.OverlapCircleAll(positionWeapon, gunStats.enemyDectionRadius, layerEnemy);

            _enemyNearest = findEnemys.AsEnumerable()
                .OrderBy(e => Vector2.Distance(positionWeapon, e.transform.position))
                .FirstOrDefault(e => Vector2.Distance(positionWeapon, e.transform.position) < gunStats.enemyDectionRadius);
        }

        private void AimingTarget()
        {
            var positionWeapon = this.transform.position;
            var velocity = Utils.GetVelocity(_enemyNearest.transform.position, positionWeapon, 1);

            Quaternion transformRotation = MathHelpers.Vector2ToQuaternion(velocity);
            this.transform.rotation = transformRotation;

        }

        private void Shooting()
        {
            if (_timeDelayShooting == 0)
            {
                var position = _enemyNearest.transform.position;

                var bulletIns = Utils.Instantiate(bullet, shootingPoint.position);
                bulletIns.OnInit(position);

                muzzleFlash.Show();
            }

            _timeDelayShooting += Time.deltaTime;

            if (_timeDelayShooting > gunStats.timeShooting)
            {
                _timeDelayShooting = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(4, 4, 4, 0.1f);
            Gizmos.DrawSphere(this.transform.position, gunStats.enemyDectionRadius);
        }
    }
}