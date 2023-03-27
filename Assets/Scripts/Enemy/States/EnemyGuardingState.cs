using UnityEngine;

public class EnemyGuardingState : EnemyBaseState
{
     public override void EnterState(EnemyStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.startingPosition);
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        
    }
    public override void OnPlayerDetection(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.chasingState);
    }
    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {
        
    }
}
