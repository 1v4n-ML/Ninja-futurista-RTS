using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Hurt")]
public class HurtPowerUp : PowerUpEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<HealthManager>().TakeDamage(amount);
    }
}