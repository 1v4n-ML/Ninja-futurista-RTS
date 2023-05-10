using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemySearchingState : EnemyBaseState
{
    private Vector3 wanderPoint;

     public override void EnterState(EnemyStateManager enemy)
    {
        enemy.StartCoroutine(StopSearch(enemy));
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        if (wanderPoint == Vector3.zero || Vector3.Distance(enemy.transform.position, wanderPoint) < 2f)
        {
            // Generate a new random point nearby
            NavMesh.SamplePosition(enemy.transform.position + Random.insideUnitSphere * enemy.enemyDetails.wanderRadius, out NavMeshHit hit, enemy.enemyDetails.wanderRadius, NavMesh.AllAreas);
            wanderPoint = hit.position;
            //Debug.Log("wandering" + wanderPoint);
        }
        enemy.agent.SetDestination(wanderPoint);
        
    }
    public override void OnPlayerDetection(EnemyStateManager enemy)
    {
        enemy.StopCoroutine(StopSearch(enemy));
        enemy.SwitchState(enemy.chasingState);
    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {
        
    }
    private IEnumerator StopSearch(EnemyStateManager instance)
    {
        yield return new WaitForSecondsRealtime(instance.enemyDetails.searchTime);
        instance.SwitchState(instance.originalState);
    }

    public override void PlayerInRange(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.attackingState);
    }

    public override void PlayerLeftRange(EnemyStateManager enemy)
    {

    }
}