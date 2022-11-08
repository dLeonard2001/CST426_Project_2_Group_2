using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SeekBehavior : SteeringBehavior
{
    [SerializeField] private float targetReachedThreshold = 0.5f;
    [SerializeField] private bool showGizmo = true;
    bool reachedLastTarget = true;

    private Vector3 targetPositionCached;
    private float[] interestsTemp;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, EnemyData enemyData)
    {
        //if we do not find target, stop seeking
        //else set a new target to reach
        if(reachedLastTarget)
        {
            if(enemyData.targets == null || enemyData.targets.Count <= 0)
            {
                enemyData.currentTarget = null;
                return (danger, interest);
            }
            else
            {
                reachedLastTarget = false;
                enemyData.currentTarget = enemyData.targets.OrderBy
                    (target => Vector2.Distance(target.position, transform.position)).FirstOrDefault();
            }
        }
        //cache the last position only if we still see the target(player)
        if(enemyData.currentTarget != null && enemyData.targets != null && enemyData.targets.Contains(enemyData.currentTarget))
            targetPositionCached = enemyData.currentTarget.position;

        //First check if we have reached the target
        if(Vector3.Distance(transform.position, targetPositionCached) < targetReachedThreshold)
        {
            reachedLastTarget = true;
            enemyData.currentTarget = null;
            return (danger, interest);
        }
        //if we haven't yet reach the target do the main logic of finding the interest directions
        Vector3 directionToTarget = (targetPositionCached - transform.position);
        
        for (int i = 0; i < interest.Length; i++)
        {
            float result = Vector3.Dot(directionToTarget.normalized, Directions.eightDirections[i]);

            if(result > 0)
            {
                if(result > interest[i])
                {
                    interest[i] = result;
                }
            }
        }
        interestsTemp = interest;
        return (danger, interest);
    }

    private void OnDrawGizmos()
    {
        if(!showGizmo) return;

        Gizmos.DrawSphere(targetPositionCached, 0.2f);

        if(Application.isPlaying && interestsTemp != null)
        {
            if(interestsTemp != null)
            {
                Gizmos.color = Color.green;
                for (int i = 0; i < interestsTemp.Length; i++)
                {
                    Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * interestsTemp[i] * 3);
                }
                if(!reachedLastTarget)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(targetPositionCached, 0.1f);
                }
            }
        }

    }
}
