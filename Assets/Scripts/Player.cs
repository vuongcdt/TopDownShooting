using System;
using System.Linq;
using Scritps;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject muzzle;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float timeShooting = 0.1f;
    [SerializeField] private float timeDelayShooting = 1f;
    [SerializeField] private float speedBullet = 20;
    [SerializeField] private LayerMask layerEnemy;
    [SerializeField] private float enemyDectionRadius = 5;

    private bool _isShooting;
    private float _timeDelayShooting;

    private void Start()
    {
        _timeDelayShooting = timeDelayShooting;
    }

    private void Update()
    {
        var positionPlayer = gameObject.transform.position;
        var findEnemys = Physics2D.OverlapCircleAll(positionPlayer, enemyDectionRadius, layerEnemy);
        var enemyNearest = findEnemys
            .ToList()
            .OrderBy(e => Vector2.Distance(positionPlayer, e.transform.position))
            .FirstOrDefault(e => Vector2.Distance(positionPlayer, e.transform.position) < enemyDectionRadius);

        if (!enemyNearest)
        {
            return;
        }

        var velocity = TouchController.GetVelocity(enemyNearest.transform.position, positionPlayer, speedBullet);
        var rad2Deg = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        Quaternion transformRotation = Quaternion.AngleAxis(rad2Deg, Vector3.forward);
        weapon.transform.rotation = transformRotation;

        Shooting(transformRotation, velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(4, 4, 4, 0.1f);
        Gizmos.DrawSphere(gameObject.transform.position, enemyDectionRadius);
    }

    private void Shooting(Quaternion transformRotation, Vector2 velocity)
    {
        _timeDelayShooting -= Time.deltaTime;

        if (_timeDelayShooting > 0) return;

        if (_timeDelayShooting < -timeShooting)
        {
            _timeDelayShooting = timeDelayShooting;
            muzzle.SetActive(false);
            _isShooting = false;
            return;
        }

        if (_isShooting) return;

        muzzle.SetActive(true);

        var bulletObjectGame = Instantiate(bullet, shootingPoint.position, transformRotation);
        _isShooting = true;

        var rigibody2dBullet = bulletObjectGame.GetComponent<Rigidbody2D>();
        rigibody2dBullet.velocity = velocity;
    }
}