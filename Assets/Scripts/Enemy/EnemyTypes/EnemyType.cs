using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType")]
public class EnemyType : ScriptableObject {
    public string enemyName;
    public behaviourTypes behaviour;
    [Header("Attributes")]
    public float moveSpeed;
    public float HP;
    public float atkRange;
    [Range(0.1f,3f)]
    public float atkSpeed;
    public float damage;
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
    
    public enum behaviourTypes
    {
        Chaser,
        Patroller,
        Guard
    }

}
