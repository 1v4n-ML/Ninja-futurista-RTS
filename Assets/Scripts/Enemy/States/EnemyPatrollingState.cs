using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("entering patrolling state");
        enemy.enemyDetails.targetWaypoint = enemy.enemyDetails.waypoints[enemy.enemyDetails.waypointIndex].position;
        enemy.agent.SetDestination(enemy.enemyDetails.targetWaypoint);
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.enemyDetails.targetWaypoint = enemy.enemyDetails.waypoints[enemy.enemyDetails.waypointIndex].position;
        enemy.agent.SetDestination(enemy.enemyDetails.targetWaypoint);
        if (Vector3.Distance(enemy.transform.position, enemy.enemyDetails.targetWaypoint) < 2)
        {
            enemy.enemyDetails.waypointIndex++;
            if (enemy.enemyDetails.waypointIndex == enemy.enemyDetails.waypoints.Length)
            {
                enemy.enemyDetails.waypointIndex = 0;
            }
        }
    }
    public override void OnPlayerDetection(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.chasingState);
    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {

    }
}
