using UnityEngine;
using UnityEngine.AI;

public class EnemyBeahvior : MonoBehaviour // DEPRECATED
{
    [Header("Rerefências")]
    [SerializeField]
    private NavMeshAgent enemyAgent;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private EnemyType enemyDetails;
    private Vector3 startingPosition;
    private bool OnPatrol;

    

    void Start()
    {
        enemyAgent.speed = enemyDetails.moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;
    }

    void Update()
    {
        if (enemyDetails.behaviour == EnemyType.behaviourTypes.Chaser )
        {
            Chase();
        }
        if (enemyDetails.behaviour == EnemyType.behaviourTypes.Patroller )
        {
            Patrol();
        }
        if (enemyDetails.behaviour == EnemyType.behaviourTypes.Guard )
        {
            Guard();
        }
    }
    public void Patrol(){
        enemyDetails.targetWaypoint = enemyDetails.waypoints[enemyDetails.waypointIndex].position;

        if (OnPatrol)
        {
            enemyAgent.SetDestination(enemyDetails.targetWaypoint);
        }

        if (Vector3.Distance(transform.position, enemyDetails.targetWaypoint)<1 && OnPatrol)
        {
            enemyDetails.waypointIndex++;
            if (enemyDetails.waypointIndex == enemyDetails.waypoints.Length)
            {
                enemyDetails.waypointIndex =0;
            }
        }

        float _dist = Vector3.Distance(transform.position,player.transform.position);
        if (_dist < enemyDetails.visionRadius)
        {
            OnPatrol = false;
            enemyAgent.SetDestination(player.transform.position);    
        }else OnPatrol = true;
    }
    public void Chase(){
        float _dist = Vector3.Distance(transform.position,player.transform.position);
        enemyAgent.SetDestination(player.transform.position);


        if(_dist < enemyDetails.visionRadius){
            enemyAgent.speed = enemyDetails.chaseSpeed;
        }else {
            enemyAgent.speed = enemyDetails.moveSpeed;
        }

    }
    public void Guard(){
        float _dist = Vector3.Distance(transform.position,player.transform.position);
        if(_dist < enemyDetails.visionRadius){
            enemyAgent.speed = enemyDetails.chaseSpeed;
            enemyAgent.SetDestination(player.transform.position);
        }else {
            enemyAgent.speed = enemyDetails.moveSpeed;
            enemyAgent.SetDestination(startingPosition);
        }
    }
}
