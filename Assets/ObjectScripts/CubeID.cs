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
        EditorGUILayout.BeginHorizontal();

        //Make button for selecting all cubes
        if (GUILayout.Button("Select all cubes"))
        {
            CubeID[] allCubeBehaviour = GameObject.FindObjectsOfType<CubeID>();
            var allCubeObjects = allCubeBehaviour
            .Select(cube => cube.gameObject)
            .ToArray();
            Selection.objects = allCubeObjects;

        }
       
        //Button for deselecting objects
        if(GUILayout.Button("Clear selection")) 
        {
            Selection.objects = new Object[]  { (target as CubeID).gameObject };
        }
        EditorGUILayout.EndHorizontal();
         
        //Making the Disable and enable button, makes the cubes disappear and disables in hierarchy
        if (GUILayout.Button("Disable/Enable all cubes", GUILayout.Height(40)))
        //Trying to turn this button green 
        {  
             Color cachedColor = GUI.backgroundColor;
             GUI.backgroundColor = Color.green;
             foreach (var cube in GameObject.FindObjectsOfType<CubeID>(true)) 
             {
             cube.gameObject.SetActive(!cube.gameObject.activeSelf);
             }
             GUI.backgroundColor = cachedColor;
         }     
     }
}
#endif

