using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorTools : EditorWindow
{
    [MenuItem("Tools/EditorTools")]
    // Start is called before the first frame update
    static void Init()
    {
        var window = EditorWindow.GetWindow(typeof(EditorTools));
        window.titleContent = new GUIContent("EditorTools");
        window.Show();
    }
    
    void OnGUI()
    {
        if (GUILayout.Button("ClearSave"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
