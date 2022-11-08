using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    public LayerMask groundLayer;
    public float portalRadius;
    public bool showGizmos;

    [SerializeField] private Transform randomPosition;
    [SerializeField] private Transform centerPosition;
    private void Start()
    {
        RandomPosition();
    }

    public Transform SearchPosition()
    {
        return randomPosition;
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, portalRadius);
    }

    public void RandomPosition()   
    {
        var position = transform.position;

        randomPosition.position = new Vector3(Random.Range(position.x - portalRadius, position.x + portalRadius), 5, Random.Range(position.z - portalRadius, position.z + portalRadius));
    }
    

}
