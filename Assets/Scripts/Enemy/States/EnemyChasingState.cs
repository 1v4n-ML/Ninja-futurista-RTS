using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
     public override void EnterState(EnemyStateManager enemy)
    {
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
        if (enemy.enemyDetails.behaviour == EnemyType.behaviourTypes.Chaser || enemy.enemyDetails.behaviour == EnemyType.behaviourTypes.Patroller)
        {
            enemy.SwitchState(enemy.searchingState);
        }else
            enemy.SwitchState(enemy.originalState);
    }
    
}
