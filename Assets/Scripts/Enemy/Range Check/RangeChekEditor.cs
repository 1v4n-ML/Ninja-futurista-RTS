using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RangeCheck))]
public class RangeChekEditor : Editor
{
    private void OnSceneGUI()
    {
        RangeCheck range = (RangeCheck)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(range.transform.position, Vector3.up, Vector3.forward, 360, range.enemyDetails.atkRange);
    }
}
