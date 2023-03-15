using UnityEngine;

public abstract class EnemyBaseState //abstract class made to simplify creation of new states and to define mandatory methods for each one
{ 
    public abstract void EnterState(EnemyStateManager enemy); // simulate start method for every state
    public abstract void UpdateState(EnemyStateManager enemy); // simulate update method for every state
    public abstract void OnPlayerDetection(EnemyStateManager enemy); // instructions for when player is seen
    public abstract void LostSightOfPlayer(EnemyStateManager enemy); // instructions for when player leaves  vision range
}
