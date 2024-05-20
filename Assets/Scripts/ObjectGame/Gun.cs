using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private MuzzleFlash _muzzleFlash;
        [SerializeField] private Bullet bullet;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private float timeDelayShooting = 1f;
        [SerializeField] private LayerMask layerEnemy;
        [SerializeField] private float enemyDectionRadius = 5;

        private float _timeDelayShooting;
        private readonly List<Bullet> _bullets = new();

        private void Update()
        {
            var enemyNearest = FindEnemy();

            if (enemyNearest)
            {
                TargetAiming(enemyNearest);
                return;
            }

            gameObject.transform.rotation = Quaternion.identity;
        }

        private Collider2D FindEnemy()
        {
            var positionWeapon = gameObject.transform.position;
            var findEnemys = Physics2D.OverlapCircleAll(positionWeapon, enemyDectionRadius, layerEnemy);

            var enemyNearest = findEnemys.AsEnumerable()
                .OrderBy(e => Vector2.Distance(positionWeapon, e.transform.position))
                .FirstOrDefault(e => Vector2.Distance(positionWeapon, e.transform.position) < enemyDectionRadius);

            return enemyNearest;
        }

        private void TargetAiming(Collider2D enemyNearest)
        {
            var positionWeapon = gameObject.transform.position;
            var velocity = Utils.GetVelocity(enemyNearest.transform.position, positionWeapon, 1);

            Quaternion transformRotation = MathHelpers.Vector2ToQuaternion(velocity);
            gameObject.transform.rotation = transformRotation;

            Shooting(enemyNearest);
        }

        private void Shooting(Collider2D enemyNearest)
        {
            if (_timeDelayShooting == 0)
            {
                var position = enemyNearest.transform.position;

                var bulletIns = Utils.Instantiate(bullet, shootingPoint.position, _bullets);
                bulletIns.WakeUp(position);

                _muzzleFlash.Show();
            }

            _timeDelayShooting += Time.deltaTime;

            if (_timeDelayShooting > timeDelayShooting)
            {
                _timeDelayShooting = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(4, 4, 4, 0.1f);
            Gizmos.DrawSphere(gameObject.transform.position, enemyDectionRadius);
        }
    }
}