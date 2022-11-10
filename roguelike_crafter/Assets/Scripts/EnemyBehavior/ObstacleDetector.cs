using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : Detector
{
    [SerializeField] private float detectionRadius = 2;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool showGizmos = true;
    private Collider[] colliders = null;

    public override void Detect(EnemyData enemyData)
    {
        colliders = Physics.OverlapSphere(transform.position, detectionRadius, layerMask);
        enemyData.obstacles = colliders;
    }

    private void OnDrawGizmos()
    {
        if(!showGizmos)
        {
            return;
        }
        if(Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach(Collider obstacle in colliders)
            {
                Gizmos.DrawSphere(obstacle.transform.position, 0.5f);
            }
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
