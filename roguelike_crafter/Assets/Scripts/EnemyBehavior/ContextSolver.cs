using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{
    [SerializeField] private bool showGizmos = true;

    public float[] interestGizmo;
    Vector3 resultDirection = Vector3.zero;
    private float rayLength = 1;
    //[SerializeField] private float safetyDistance = 20f;

    private void Start()
    {
        interestGizmo = new float[8];
    }

    public Vector3 GetDirectionToMove(List<SteeringBehavior> behaviors, EnemyData enemyData)
    {
        float[] danger = new float[8];
        float[] interest = new float[8];

        foreach (var behaviour in behaviors)
        {
            (danger, interest) = behaviour.GetSteering(danger, interest, enemyData);
        }

        for (int i = 0; i < 8; i++)
        {
            //make sure the value is between 0 and 1
            interest[i] = Mathf.Clamp01(interest[i] - danger[i]);
        }


        //if(enemyData.currentTarget.position != null && enemyData.currentTarget.CompareTag("Player"))
        // {
        //     if(Vector3.Distance(transform.position, enemyData.currentTarget.position) < safetyDistance)
        //     {
        //         float max = 0, min = 1;
        //         int maxIndex = 0, minIndex = 0;
        //         for (int i = 0; i < 8; i++)
        //         {
        //             if(interest[i] > max)
        //             {
        //                 maxIndex = i;
        //                 max = interest[i];
        //             }
        //             if(interest[i] < min && interest[i] != 0)
        //             {
        //                 minIndex = i;
        //                 min = interest[i];
        //             }
        //         }

        //         interest[minIndex] = Mathf.Clamp01( min * 2);
        //         interest[maxIndex] = Mathf.Clamp01( max / 2);
        //     }
        // }

        interestGizmo = interest;

        //get the average direction
        Vector3 outputDirection = Vector3.zero;

        for (int i = 0; i < 8; i++)
        {
            outputDirection += Directions.eightDirections[i] * interest[i];
        }
        outputDirection.Normalize();

        resultDirection = outputDirection;


        return resultDirection;
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying && showGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, resultDirection * rayLength);
        }
    }
}
