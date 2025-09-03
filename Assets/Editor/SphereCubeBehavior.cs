using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;




public class SphereCubeBehavior : MonoBehaviour
{
    public float size;
}



#if UNITY_EDITOR
[CustomEditor(typeof(SphereCubeBehavior))]
public class SphereCubeBehaviorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        //Call base editor
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

        //Make button for selecting all spheres
        if(GUILayout.Button("Select all spheres"))
        {
            SphereID[] _allSpheres = FindObjectsByType<SphereID>(FindObjectsSortMode.None);
            GameObject[] _allSphereObjects = _allSpheres
           .Select(_sphere => _sphere.gameObject)
           .ToArray();
            Selection.objects = _allSpheres;
        }


    }

}
#endif
