using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    private int maxEnemies = 10;
   
    void Start()
    {
        StartCoroutine(Spawn(spawnInterval,enemyPrefab));
    }
    private IEnumerator Spawn(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        if (maxEnemies > 0)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            maxEnemies--;
            StartCoroutine(Spawn(spawnInterval,enemyPrefab));
        }   
    }
}
