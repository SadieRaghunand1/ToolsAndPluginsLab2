using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CubeID : MonoBehaviour
{
    public float size;
}

#if UNITY_EDITOR
[CustomEditor(typeof(CubeID)), CanEditMultipleObjects] 
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //Make button for selecting all cubes
        if (GUILayout.Button("Select all cubes"))
        {
            var allCubeBehaviour = GameObject.FindObjectsOfType<CubeID>();
            var allCubeObjects = allCubeBehaviour
            .Select(cube => cube.gameObject)
            .ToArray();
            Selection.objects = allCubeObjects;

        }
    }
}
#endif

