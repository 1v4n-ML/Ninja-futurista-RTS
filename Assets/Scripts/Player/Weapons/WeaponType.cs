using UnityEngine;

[CreateAssetMenu(menuName = "WeaponType")]
public class WeaponType : ScriptableObject
{
    public string label;
    public float range;
    public float dmg;
    [Range(0.1f,5f)]
    public float atkSpeed;
    public Sprite icon;
    //public bool ranged; //?

}
