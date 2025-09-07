using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;
#endif


[ExecuteInEditMode]
public class CubeID : MonoBehaviour
{
    public float size;

    private void Update()
    {
        //Change this cube's scale
        transform.localScale = new Vector3(size, size, size);

    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(CubeID)), CanEditMultipleObjects] 
public class CubeEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.BeginHorizontal();

        //Get this cube's script for the size
        CubeID _thisCube = (CubeID)target;

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


        //Set variables for the colors of the enable/disable button and the button style
        bool _enabled = FindAnyObjectByType<CubeID>(FindObjectsInactive.Include).gameObject.activeSelf;
        Color _enabledColor = Color.green;
        Color _disabledColor = new Color(75, 0, 200);
        GUIStyle _style = new GUIStyle(GUI.skin.button);

        //Check which texture to show on button
        //(green - currently on, purple/pink - currently off)
        if (_enabled)
        {
            GUI.backgroundColor = _enabledColor;
            _style.normal.textColor = Color.black;
        }
        else
        {
            GUI.backgroundColor = _disabledColor;
            _style.normal.textColor = Color.black;
        }

        //Making the Disable and enable button, makes the cubes disappear and disables in hierarchy
        if (GUILayout.Button("Disable/Enable all cubes", _style))
        //Change button color based on if on/off 
        {
            // Color _cachedColor = _disabledColor;
            GUI.backgroundColor = Color.green;
            foreach (var cube in GameObject.FindObjectsOfType<CubeID>(true))
            {
                cube.gameObject.SetActive(!cube.gameObject.activeSelf);
            }
        }

        CheckForSizeWarning(_thisCube.size);

      
     }


    //Make a texture for the button to allow changing the background color
    private Texture2D MakeButtonTexture(int _width, int _height, Color _color)
    {
        //Create texture pixels of specified height, width, and color 
        Color[] pix = new Color[_width * _height];

        for (int i = 0; i < pix.Length; i++)
            pix[i] = _color;

        Texture2D result = new Texture2D(_width, _height);
        result.SetPixels(pix);
        result.Apply();

        //return texture
        return result;
    }

    //Generate warning if the cube's size is greater than 2
    private void CheckForSizeWarning(float _size)
    {
        if(_size > 2)
        {
            EditorGUILayout.HelpBox("Size cannot be greater than 2!", MessageType.Warning);
        }
    }
}
#endif

