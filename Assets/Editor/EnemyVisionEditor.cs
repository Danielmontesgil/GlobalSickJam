using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyVision))]
public class EnemyVisionEditor : Editor
{

    void OnSceneGUI()
    {
        EnemyVision fow = (EnemyVision)target;
        Handles.color = Color.white;
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.range);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.range);
    }

}
