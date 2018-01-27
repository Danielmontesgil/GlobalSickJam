using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Vision))]
public class VisionEditor : Editor
{

    void OnSceneGUI()
    {
        Vision fow = (Vision)target;
        Handles.color = Color.white;
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.range);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.range);
    }

}
