using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
     public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("entering chasing state");
        enemy.agent.SetDestination(enemy.playerRef.transform.position);
        enemy.agent.speed = enemy.enemyDetails.chaseSpeed;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.playerRef.transform.position);
    }
    public override void OnPlayerDetection(EnemyStateManager enemy)
    {

    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {
        enemy.agent.speed = enemy.enemyDetails.moveSpeed;
        enemy.SwitchState(enemy.originalState);
    }
}
