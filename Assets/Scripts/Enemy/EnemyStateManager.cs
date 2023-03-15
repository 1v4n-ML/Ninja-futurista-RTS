using UnityEngine.AI;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [Header("Tipo de inimigo (SO)")]
    public EnemyType enemyDetails; // enemy type scriptable object
    public GameObject route;

    [Header("States")]
    public EnemyBaseState currentState;
    public EnemyBaseState originalState;
    public EnemyChasingState chasingState = new EnemyChasingState();
    public EnemyGuardingState guardingState = new EnemyGuardingState();
    public EnemyPatrollingState patrollingState = new EnemyPatrollingState();

    [Header("Referências")]
    public GameObject playerRef; // reference to the player on the scene
    public NavMeshAgent agent;
    public FieldOfView vision; // reference to the vision script
    public Vector3 startingPosition; // variable to save original guarding spot

    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<FieldOfView>();
        startingPosition = transform.position;
        if (route)
        {   
            enemyDetails.waypoints =  route.GetComponentsInChildren<Transform>();
        }

        switch (enemyDetails.behaviour) 
        {   // setting the intial state depending on enemy type
            case EnemyType.behaviourTypes.Chaser: 
                currentState = guardingState;
                originalState = guardingState;
                currentState.EnterState(this);
                break;
            case EnemyType.behaviourTypes.Patroller:
                currentState = patrollingState;
                originalState = patrollingState;
                currentState.EnterState(this);
                break;
            case EnemyType.behaviourTypes.Guard:
                currentState = guardingState;
                originalState = guardingState;
                currentState.EnterState(this);
                break;
            default: 
                currentState = guardingState;
                originalState = guardingState;
                currentState.EnterState(this);
                break;
        } 
 
    }

    void Update()
    {
        currentState.UpdateState(this);

        if(vision.canSeePlayer){
            Debug.Log("ó o pepinão ali!"+ this);
            currentState.OnPlayerDetection(this);
        }else {
            currentState.LostSightOfPlayer(this);
        }
    }
    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }
    
}

