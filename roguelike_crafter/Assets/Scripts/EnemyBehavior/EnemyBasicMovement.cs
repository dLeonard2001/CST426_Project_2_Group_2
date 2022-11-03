using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBasicMovement : MonoBehaviour
{
    [SerializeField] private List<SteeringBehavior> steeringBehaviors;
    [SerializeField] private List<Detector> detectors;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float detectionDelay = 0.05f, aiUpdateDelay = 0.06f;
    [SerializeField] private ContextSolver movementDirectionSolver;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 movementDirection = Vector3.zero;
    private bool isChasing = false;
    private bool isPatrol = false;
    
    [SerializeField] private float safetyDistance;

    private void Start()
    {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
        //StartCoroutine(IErandomDirection());
    }

    private void PerformDetection()
    {
        foreach (var detector in detectors)
        {
            detector.Detect(enemyData);
        }
    }

    private void Update()
    {
        if(enemyData.currentTarget != null)
        {
            transform.LookAt(enemyData.currentTarget);
            if(!isChasing)
            {
                isChasing = true;
                StartCoroutine(ChaseAndAttack());
            }
            //Vector3.MoveTowards(transform.position, enemyData.currentTarget.position, speed * Time.deltaTime);
        }
        else if(enemyData.GetTargetsCount() > 0)
        {
            enemyData.currentTarget = enemyData.targets[0];
        }

        //MoveFunction
        GetComponent<Rigidbody>().AddForce(movementDirection * speed * Time.deltaTime);

        if(isPatrol)
        {

        }
    }

    private IEnumerator ChaseAndAttack()
    {
        if(enemyData.currentTarget == null) // lost player
        {
            movementDirection = Vector3.zero;
            isChasing = false;
            StartCoroutine(BackToPortal());
            yield break;
        }
        else
        {
            float distance = Vector3.Distance(enemyData.currentTarget.position, transform.position);
            
            if(distance < safetyDistance)
            {
                movementDirection = Vector3.zero;
                //Attack
                //Debug.Log("GetYou");

                yield return new WaitForSeconds(0.5f);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                movementDirection = movementDirectionSolver.GetDirectionToMove(steeringBehaviors, enemyData);
                //AddRandomDirection(ref movementDirection);
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }
        }
    }

    private void AddRandomDirection(ref Vector3 direction)
    {
        if(Vector3.Distance(transform.position, enemyData.currentTarget.position) <= safetyDistance)
        {
            //direction += RandomDirection.normalized;
        }
    }

    IEnumerator BackToPortal()
    {
        float time = 0;
        while(time <= 4)
        {
            if(enemyData.currentTarget != null)
            {
                break;
            }
            time += Time.deltaTime;
            yield return null;
        }

        if(enemyData.currentTarget == null)
        {
            enemyData.currentTarget = GetComponentInParent<PatrolBehavior>().SearchPosition();
        }

        yield return null;

    }

    // IEnumerator IErandomDirection()
    // {
    //     // RandomDirection = transform.TransformPoint(Vector3.right) * UnityEngine.Random.Range(-1, 1);
    //     // //Debug.Log(transform.right);
    //     // yield return new WaitForSeconds(3f);
    //     // if(isChasing)
    //     // {
    //     //     StartCoroutine(IErandomDirection());
    //     // }
    // }
}
