using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EditorTools : EditorWindow
{
    private string wagonName;
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
        if (GUILayout.Button("Clear Save"))
        {
            PlayerPrefs.DeleteAll();
        }
        GUILayout.Space(20);
        GUILayout.Label("Wagon Name:");
        wagonName = GUILayout.TextField(wagonName);
        if (GUILayout.Button("Add Wagon"))
        {
            var wagon = GameManager.Instance.WagonData.FirstOrDefault(w => w.Name == wagonName);
            if (wagon != null)
            {
                FindObjectOfType<Vehicle>().AddWagon(wagon);
            }
        }

        
    }
}
