using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.enemyDetails.waypointIndex = 0;
        enemy.enemyDetails.targetWaypoint = enemy.enemyDetails.waypoints[enemy.enemyDetails.waypointIndex].position;
        enemy.agent.SetDestination(enemy.enemyDetails.targetWaypoint);
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        Patrol(enemy);
    }
    public override void OnPlayerDetection(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.chasingState);
    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {

    }
    private void Patrol(EnemyStateManager instance){

        instance.enemyDetails.targetWaypoint = instance.enemyDetails.waypoints[instance.enemyDetails.waypointIndex].position;
        instance.agent.SetDestination(instance.enemyDetails.targetWaypoint);
        if (Vector3.Distance(instance.transform.position, instance.enemyDetails.targetWaypoint) < 2)
        {
            instance.enemyDetails.waypointIndex++;
            if (instance.enemyDetails.waypointIndex >= instance.enemyDetails.waypoints.Length)
            {
                instance.enemyDetails.waypointIndex = 0;
            }
        }
    }
}
