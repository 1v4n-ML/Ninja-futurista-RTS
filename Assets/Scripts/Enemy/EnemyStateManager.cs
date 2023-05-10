using UnityEngine.AI;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private bool hasSeenPlayer;
    private bool wasAttakingPlayer;
    [Header("Tipo de inimigo (SO)")]
    public EnemyType enemyDetails; // enemy type scriptable object
    public GameObject route;

    [Header("States")]
    public EnemyBaseState currentState;
    public EnemyBaseState originalState;
    public EnemyChasingState chasingState = new EnemyChasingState();
    public EnemyGuardingState guardingState = new EnemyGuardingState();
    public EnemyPatrollingState patrollingState = new EnemyPatrollingState();
    public EnemySearchingState searchingState = new EnemySearchingState();
    public EnemyAttackingState attackingState = new EnemyAttackingState();

    [Header("Referências")]
    public GameObject playerRef; // reference to the player on the scene
    public NavMeshAgent agent;
    public FieldOfView vision; // reference to the vision script
    public Vector3 startingPosition; // variable to save original guarding spot
    public LayerMask playerLayer; // reference for the search state
    public Animator animator; // reference for the animator component
    public RangeCheck rangeCheck; //reference for the script that makes verifies atk range

    void Start()
    {
        GetReferences();
        startingPosition = transform.position;
        agent.stoppingDistance = enemyDetails.atkRange - 0.2f;

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

        //check if player is in vision range
        if (vision.canSeePlayer)
        {
            currentState.OnPlayerDetection(this);
            hasSeenPlayer = true; 
        }
        else
        {
            if (hasSeenPlayer)
            {
                currentState.LostSightOfPlayer(this);
                hasSeenPlayer = false; 
            }
        }
        //check if player is in atk range
        if (rangeCheck.isInRange)
        {
            currentState.PlayerInRange(this);
            wasAttakingPlayer = true;
        }else
        {
            if (wasAttakingPlayer)
            {
                currentState.PlayerLeftRange(this);
                wasAttakingPlayer = false;
            }
        }
    }
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    
    private void GetReferences()
    {
        if (route)
        {   
            enemyDetails.waypoints =  route.GetComponentsInChildren<Transform>();
        }
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<FieldOfView>();
        animator = GetComponent<Animator>();
        rangeCheck = GetComponent<RangeCheck>();
    }
    public void FaceTarget()
    {
        Vector3 direction = (playerRef.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}

