using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType")]
public class EnemyType : ScriptableObject {
    public string enemyName;
    public float moveSpeed;
    public int HP;
    public behaviourTypes behaviour;
    public enum behaviourTypes
    {
        Chaser,
        Patroller,
        Guard
    }
    [Header("Patrolling variables")]
    public Transform[] waypoints;
    public int waypointIndex;
    public Vector3 targetWaypoint;
    [Header("Chasing variables")]
    public int chaseSpeed;

    [Header("Search variables")]
    [Range(0,100)]
    public float visionRadius;
    public float searchRadius;
    public float searchTime;
    public float wanderRadius;
    

}
