using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{
    [SerializeField] private bool showGizmos = true;

    float[] interestGizmo;
    Vector3 resultDirection = Vector3.zero;
    private float rayLength = 1;

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
