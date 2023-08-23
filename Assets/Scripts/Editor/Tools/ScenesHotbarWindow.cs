using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Data.SqlClient;
using UnityEditor.SceneManagement;
using System.Security.Cryptography;

public class ScenesHotbarWindow : EditorWindow
{
    [MenuItem("Window/Hotbar")]
    public static void ShowWindow()
    {
        ScenesHotbarWindow window = (ScenesHotbarWindow)GetWindow(typeof(ScenesHotbarWindow));
        window.minSize = new Vector2(100, 100);
        window.maxSize = new Vector2(300, 300);

    }

    private void OnGUI()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        
        for (int i = 0; i < sceneCount; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);

            if (GUILayout.Button(GetSceneNameFromPath(path)))
            {
                EditorSceneManager.OpenScene(path);
            }
        }
    }

    private string GetSceneNameFromPath(string path)
    {
        int slashIndex = path.LastIndexOf('/');
        int dotIndex = path.LastIndexOf('.');
        //
        string nameWithoutExtension = path.Substring(0, dotIndex);
        string name = nameWithoutExtension.Substring(slashIndex + 1, nameWithoutExtension.Length - slashIndex - 1);
        return name;
    }
}
