using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CubeID : MonoBehaviour
{
    public float size;
}

#if UNITY_EDITOR
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        //Make button for selecting all cubes
        if (GUILayout.Button("Select all cubes"))
        {
            CubeID[] _allCubes = FindObjectsByType<CubeID>(FindObjectsSortMode.None);
            GameObject[] _allCubeObjects = _allCubes
            .Select(_cube => _cube.gameObject)
            .ToArray();
            Selection.objects = _allCubes;

        }
    }
}
#endif
