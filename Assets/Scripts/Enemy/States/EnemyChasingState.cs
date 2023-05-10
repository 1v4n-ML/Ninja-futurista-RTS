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
        GameObject _target = enemy.playerRef; //cache playerRef

        enemy.agent.SetDestination(_target.transform.position); //move to player
        enemy.FaceTarget();
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

    public override void PlayerInRange(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.attackingState);
    }

    public override void PlayerLeftRange(EnemyStateManager enemy)
    {
        
    }
    
}
