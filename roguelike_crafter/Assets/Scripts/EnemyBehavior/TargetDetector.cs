using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : Detector
{
    [SerializeField] private float targetDetectionRange = 5;
    [SerializeField] private LayerMask obstacleLayer, playerLayer;
    [SerializeField] private bool showGizmos = false;
    private List<Transform> colliders;
    public override void Detect(EnemyData enemyData)
    {
        Collider[] playerCollider = Physics.OverlapSphere(transform.position, targetDetectionRange, playerLayer);
        if (playerCollider.Length > 0)
        {
            Vector3 direction = (playerCollider[0].transform.position - transform.position).normalized;
            RaycastHit hit;
            Physics.Raycast(transform.position, direction, out hit, targetDetectionRange, obstacleLayer);

            if (hit.collider != null && (playerLayer & (1 << hit.collider.gameObject.layer)) != 0)
            {
                Debug.DrawRay(transform.position, direction * targetDetectionRange, Color.magenta);
                colliders = new List<Transform>() { playerCollider[0].transform };
            }
            else
            {
                colliders = null;
            }
        }
        else
        {
            //Enemy does not see the player
            colliders = null;
        }
        enemyData.targets = colliders;
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.DrawWireSphere(transform.position, targetDetectionRange);

        if (colliders == null) return;

        Gizmos.color = Color.magenta;
        foreach (var item in colliders)
        { 
            Gizmos.DrawSphere(item.position, 0.3f);
        }
    }
}
