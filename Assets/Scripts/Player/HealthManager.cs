using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isDead;
    public GameEvent onDeath;
    private ParticleSystem healVFX; 
    private Camera cam;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarSprite.fillAmount = 1;
        healVFX = GetComponentInChildren<ParticleSystem>();
        cam = Camera.main;
    }
    private void Update() {
        //rotate healtbar to face the camera always
        transform.rotation = Quaternion.LookRotation(transform.position-cam.transform.position);

        if(currentHealth > maxHealth) //clamp current healt to never oevrheal
        {
            currentHealth = maxHealth;
        }

        if (isDead) //check death
        {
            if (onDeath != null)
            {
                onDeath.Raise();
            }
        }
    }

    public void Heal(float amount){
        currentHealth += amount;
        healVFX.Play();
        healthBarSprite.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
        healthBarSprite.fillAmount = currentHealth / maxHealth;
        if (currentHealth < 0.1)
        {
            isDead = true;
        }
    }
}
