
using UnityEngine;
using UnityEngine.AI;

public class EnemyBeahvior : MonoBehaviour
{
    [Header("Rerefências")]
    [SerializeField]
    private NavMeshAgent enemyAgent;
    [SerializeField]
    private GameObject player;


    [Header("Atributos")]
    [SerializeField]
    private float visionRadius;
    [SerializeField]
    private int chaseSpeed = 10;
    private float normalSpeed;
    //public float moveSpeed;
    
    void Start()
    {
       normalSpeed = enemyAgent.speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float _dist = Vector3.Distance(transform.position,player.transform.position);
        enemyAgent.SetDestination(player.transform.position);

        if(_dist < visionRadius){
            enemyAgent.speed = chaseSpeed;
        }else enemyAgent.speed = normalSpeed;
    }
}
