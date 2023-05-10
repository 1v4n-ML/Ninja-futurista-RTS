using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponType equippedWeapon;
    private PlayerMotor motor;
    private Animator animator;
    [SerializeField]
    private GameObject targetEnemy;
    Camera cam;
    
    void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        targetEnemy = motor.GetTarget() ? motor.GetTarget().gameObject : null;
        if (targetEnemy != null && targetEnemy.CompareTag("Enemy"))
        {
            if(RangeCheck())
            {
                animator.SetBool("Attacking", true);
                motor.StopMoving();
            }
        }else
        {
            animator.SetBool("Attacking", false);
        }
    }
    private void  Attack()
    {
        HealthManager _enemyHealth = targetEnemy.GetComponentInChildren<HealthManager>();
        _enemyHealth.TakeDamage(equippedWeapon.dmg);
    }
    private bool RangeCheck()
    {
        if (Vector3.Distance(transform.position, targetEnemy.transform.position) < equippedWeapon.range)
        {
            return true;
        }
        return false;
    }
    private void GetReferences()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        animator.speed = equippedWeapon.atkSpeed;
        motor = GetComponent<PlayerMotor>();
    }
}
