using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Startup))]
public class StartupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Startup myScript = (Startup) target;
        if (GUILayout.Button("Build Object"))
        {
            // myScript.BuildObject();
        }
    }
}