using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateManager))]
public class RangeCheck : MonoBehaviour
{
    public bool isInRange;
    private EnemyStateManager stateManager;
    public EnemyType enemyDetails;
    public LayerMask playerLayer;
    private void Start() {
        stateManager = GetComponent<EnemyStateManager>();
        enemyDetails = stateManager.enemyDetails;
        //playerLayer = stateManager.playerLayer;
        StartCoroutine(RangeCheckRoutine());
    }
    private IEnumerator RangeCheckRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while (true)
        {
            yield return wait;
            IsinRange();
        }
    }

    private void IsinRange()
    {
        if (Physics.CheckSphere(transform.position, enemyDetails.atkRange, playerLayer))
        {
            isInRange = true;
        }else
        {
            isInRange = false;
        }
    }

}
