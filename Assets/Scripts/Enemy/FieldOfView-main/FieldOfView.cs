using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;

    public EnemyType enemyDetails;
    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        enemyDetails = GetComponent<EnemyStateManager>().enemyDetails;
        radius = enemyDetails.visionRadius;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            
            Ray ray = new Ray(transform.position, directionToTarget);
            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit, distanceToTarget, obstructionMask)){
                canSeePlayer = true;
            }
            else{
                canSeePlayer = false;
            }
            
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
