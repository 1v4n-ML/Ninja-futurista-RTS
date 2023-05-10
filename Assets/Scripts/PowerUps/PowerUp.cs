using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   public PowerUpEffect powerUpEffect;
    private void OnTriggerEnter(Collider other) {    
        Debug.Log(other.name + "detectado");
        if (other.CompareTag("Player"))
        {            
            Destroy(gameObject);
            powerUpEffect.Apply(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("detectou" + other.gameObject.name);
        
    }
}
