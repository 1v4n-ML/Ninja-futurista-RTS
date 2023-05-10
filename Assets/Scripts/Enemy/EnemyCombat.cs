using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateManager))]
public class EnemyCombat : MonoBehaviour
{
    private HealthManager health;
    private HealthManager playerHealth;
    private GameObject player;
    private EnemyStateManager enemyManager;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
       
    }
  
    public void Attack()
    {
        playerHealth.TakeDamage(enemyManager.enemyDetails.damage);
    }
    private void GetReferences()
    {
        health = GetComponent<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponentInChildren<HealthManager>();
        enemyManager = GetComponent<EnemyStateManager>();
    }
    public void Die(){
        Destroy(this.gameObject,1);
    }
}