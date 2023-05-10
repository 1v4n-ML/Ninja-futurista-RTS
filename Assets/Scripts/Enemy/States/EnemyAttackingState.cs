using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.animator.speed = enemy.enemyDetails.atkSpeed;
        enemy.animator.SetBool("Attacking", true);
    }

    public override void LostSightOfPlayer(EnemyStateManager enemy)
    {
        enemy.animator.SetBool("Attacking", false);
        enemy.SwitchState(enemy.originalState);
    }

    public override void OnPlayerDetection(EnemyStateManager enemy)
    {
        
    }

    public override void PlayerInRange(EnemyStateManager enemy)
    {

    }

    public override void PlayerLeftRange(EnemyStateManager enemy)
    {
        enemy.animator.SetBool("Attacking", false);
        enemy.SwitchState(enemy.chasingState);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.FaceTarget();
    }
}
