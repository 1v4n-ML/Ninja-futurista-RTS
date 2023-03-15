using UnityEngine;

public class EnemyGuardingState : EnemyBaseState
{
     public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("entering guard state");
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
