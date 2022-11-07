using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class test : MonoBehaviour
{
    //public string path;

    //[SerializeField] private List<CurrentCharacterInfo> infos = new List<CurrentCharacterInfo>(2)
    //{
    //    new CurrentCharacterInfo(new GameObject("123"), 234, new EntityCharacteristics()),
    //    new CurrentCharacterInfo(new GameObject("321"), 123, new EntityCharacteristics())
    //};

    //void Awake()
    //{
    //    TextAsset saveFile = Resources.Load<TextAsset>("Saves/CurrentGroupSave");
    //    File.WriteAllText(AssetDatabase.GetAssetPath(saveFile), "123");
        
    //    CurrentCharacterInfo info = new CurrentCharacterInfo(new GameObject("123"), 234, new EntityCharacteristics());
    //    var ser = JsonUtility.ToJson(info, true);

    //    File.WriteAllText(path, ser);
        
    //    using (StreamReader stream = new StreamReader(path))
    //    {
    //        string json = stream.ReadToEnd();
    //    }
    //}
}

[System.Serializable]
public class test2
{
    [SerializeField] private int integer = 1;

    [SerializeField] private List<int> integers = new List<int>()
    {
        1,
        2,
        3
    };
}
