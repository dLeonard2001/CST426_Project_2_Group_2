using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public List<Transform> targets;
    public Collider[] obstacles = null;
    public Transform currentTarget;
    public int GetTargetsCount() => targets == null ? 0 : targets.Count;

    private void Update()
    {
        if(currentTarget == null && targets == null)
        {
            targets = GetComponent<EnemyBasicMovement>().patrolBehavior.GetComponent<PatrolBehavior>().GetPartolList();
        }
    }
}
