using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SphereID : MonoBehaviour
{
    public float size;
}

#if UNITY_EDITOR
[CustomEditor(typeof( SphereID)), CanEditMultipleObjects] 
public class SphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //Make button for selecting all spheres
        if (GUILayout.Button("Select all spheres"))
        {
            var allSphereBehaviour = GameObject.FindObjectsOfType<SphereID>();
            var allSphereObjects = allSphereBehaviour
            .Select(sphere => sphere.gameObject)
            .ToArray();
            Selection.objects = allSphereObjects;

        }
    }
}
#endif
