using System;
using System.Linq;
using Common;
using UnityEngine;

namespace Scritps
{
    public class Weapon:MonoBehaviour
    {
        [SerializeField] private GameObject muzzle;
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private float timeShooting = 0.1f;
        [SerializeField] private float timeDelayShooting = 1f;
        [SerializeField] private LayerMask layerEnemy;
        [SerializeField] private float enemyDectionRadius = 5;
        
        private float _timeDelayShooting;

        private void Update()
        {
            SetTargetDirection();
        }

        private void SetTargetDirection()
        {
            var positionWeapon = gameObject.transform.position;
            var findEnemys = Physics2D.OverlapCircleAll(positionWeapon, enemyDectionRadius, layerEnemy);
            var enemyNearest = findEnemys.AsEnumerable()
                .OrderBy(e => Vector2.Distance(positionWeapon, e.transform.position))
                .FirstOrDefault(e => Vector2.Distance(positionWeapon, e.transform.position) < enemyDectionRadius);

            if (!enemyNearest)
            {
                gameObject.transform.rotation = Quaternion.identity;
                muzzle.SetActive(false);
                return;
            }

            var velocity = Utils.GetVelocity(enemyNearest.transform.position, positionWeapon, 1);
            Quaternion transformRotation = MathHelpers.Vector2ToQuaternion(velocity);
            gameObject.transform.rotation = transformRotation;

            // var angle = Mathf.Atan2(velocity.y, velocity.x);
            // var transformRotation2 = Quaternion.Euler(0f, 0f, angle);
            // weapon.transform.rotation = transformRotation2;

            Shooting(transformRotation);
        }

        private void Shooting(Quaternion transformRotation)
        {
            if (_timeDelayShooting == 0)
            {
                muzzle.SetActive(true);

                Instantiate(bullet, shootingPoint.position, transformRotation);
            }

            _timeDelayShooting += Time.deltaTime;

            if (_timeDelayShooting > timeShooting)
            {
                muzzle.SetActive(false);
            }

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