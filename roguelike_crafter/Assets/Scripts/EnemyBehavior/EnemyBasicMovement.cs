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
    public float speed;
    [SerializeField] private Vector3 movementDirection = Vector3.zero;
    private bool isChasing = false;
    public float safetyDistance;
    public float distance;
    public bool needPatrol = false;
    public GameObject patrolBehavior;

    [Header("Animation")]
    public Animator anim;
    private bool isWalking;
    private bool isAttack;
    public bool isInAnimation = true;
    //[SerializeField] private GameObject patrol;

    private void Start()
    {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
        //StartCoroutine(IErandomDirection());
        if (needPatrol)
        {
            //patrol.SetActive(true);
            patrolBehavior = Instantiate(patrolBehavior);
            patrolBehavior.transform.position = transform.position;
            patrolBehavior.GetComponent<PatrolBehavior>().Init(GetComponentInChildren<TargetDetector>().targetDetectionRange);
        }
        anim = GetComponent<Animator>();
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
        if (enemyData.currentTarget != null)
        {
            distance = Vector3.Distance(enemyData.currentTarget.position, transform.position);
            if (distance > safetyDistance)
            {
                isWalking = true;
            }
            //transform.LookAt(enemyData.currentTarget);
            GetComponent<EnemyLookAt>().LookAt(movementDirection);

            if (!isChasing)
            {
                isChasing = true;
                StartCoroutine(ChaseAndAttack());
            }
            //Vector3.MoveTowards(transform.position, enemyData.currentTarget.position, speed * Time.deltaTime);
        }
        else if (enemyData.GetTargetsCount() > 0)
        {
            enemyData.currentTarget = enemyData.targets[0];
        }

        //MoveFunction


        SetAnimation();
    }

    private bool ableMove = false;
    public void Move()
    {
        ableMove = true;
    }

    public void StopMoving()
    {
        ableMove = false;
    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().AddForce(movementDirection * speed * Time.deltaTime);
        if(ableMove)
        {
            transform.position += movementDirection * Time.fixedDeltaTime * speed;
        }
    }

    private void SetAnimation()
    {
        anim?.SetBool("isFollowing", isWalking);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (enemyData.currentTarget == null) // lost player
        {
            movementDirection = Vector3.zero;
            isChasing = false;
            StartCoroutine(BackToPortal());
            yield break;
        }
        else
        {
            distance = Vector3.Distance(enemyData.currentTarget.position, transform.position);

            if (distance < safetyDistance)
            {
                movementDirection = Vector3.zero;
                isWalking = false;

                FinishAnimation();
                
                Attack();

                yield return new WaitForSeconds(GetComponent<EnemyCombat>().enemyData.attackDelay);
                
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
        if (Vector3.Distance(transform.position, enemyData.currentTarget.position) <= safetyDistance)
        {
            //direction += RandomDirection.normalized;
        }
    }

    IEnumerator BackToPortal()
    {
        float time = 0;
        while (time <= 4)
        {
            if (enemyData.currentTarget != null)
            {
                break;
            }
            time += Time.deltaTime;
            yield return null;
        }

        if (enemyData.currentTarget == null && needPatrol)
        {
            //enemyData.currentTarget = GetComponentInParent<PatrolBehavior>().SearchPosition();
        }

        yield return null;

    }

    private void Attack()
    {
        StartCoroutine(GetComponent<EnemyCombat>().Attack);
    }

    internal void FinishAnimation()
    {
        isInAnimation = false;
    }

    internal void StartAnimation()
    {
        isInAnimation = true;
    }

    public bool InAttackRange()
    {
        return distance < safetyDistance;
    }

    public bool hasTarget()
    {
        return enemyData.currentTarget;
    }

    public Transform GetTarget()
    {
        return enemyData.currentTarget;
    }

}
