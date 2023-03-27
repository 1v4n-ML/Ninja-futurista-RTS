using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class EnemySearchingState : EnemyBaseState
{
    private Vector3 wanderPoint;

     public override void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("searching");
        //enemy.StartCoroutine(SearchForPlayer(enemy));
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
        enemy.SwitchState(enemy.chasingState);
    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {
        
    }
    /* private IEnumerator SearchForPlayer(EnemyStateManager instance)
    {
        wanderPoint = Vector3.zero;
        while (true)
        {
            //Debug.Log("dentro do while");
            // wander towards a random point
            if (wanderPoint == Vector3.zero || Vector3.Distance(instance.transform.position, wanderPoint) == 1f)
            {
                // Generate a new random point nearby
                NavMesh.SamplePosition(instance.transform.position + Random.insideUnitSphere * instance.enemyDetails.wanderRadius, out NavMeshHit hit, instance.enemyDetails.wanderRadius, NavMesh.AllAreas);
                wanderPoint = hit.position;
                //Debug.Log("wandering" + wanderPoint);
            }
            instance.agent.SetDestination(wanderPoint);
            
            yield return new WaitForSeconds(1f);
        }
    } */
    private IEnumerator StopSearch(EnemyStateManager instance)
    {
        yield return new WaitForSecondsRealtime(instance.enemyDetails.searchTime);
        //instance.StopCoroutine(SearchForPlayer(instance));
        Debug.Log("not searching");
        instance.SwitchState(instance.originalState);
    }
}