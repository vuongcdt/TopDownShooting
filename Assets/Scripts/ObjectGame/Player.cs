using Scritps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerCollectable;
    [SerializeField] private float collectableDectionRadius = 1;

    private void Update()
    {
        FindCollectable();
    }

    private void FindCollectable()
    {
        var positionPlayer = gameObject.transform.position;
        var col2DCollectables = Physics2D.OverlapCircleAll(positionPlayer, collectableDectionRadius, layerCollectable);

        foreach (var collider2d in col2DCollectables)
        {
            Collectable.MoveToPlayer(positionPlayer,collider2d);       
        }
    }
}