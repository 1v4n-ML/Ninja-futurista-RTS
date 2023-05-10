using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Powerups/Healing")]
public class HealingPowerUp : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<HealthManager>().Heal(amount);
    }
}
