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

    [Header("Vision variables")]
    [Range(0,100)]
    public float visionRadius;
    [Range(0,360)]
    public float visionAngle;

}
