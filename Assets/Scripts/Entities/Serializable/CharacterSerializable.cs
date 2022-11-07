using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;

[Serializable]
public class CharacterSerializable
{
    [SerializeField] private static List<CurrentCharacterInfo> _characterInfos = new List<CurrentCharacterInfo>();
     
    private static void SetCharactersInfo()
    {
        //foreach (var character in Global.currentGroup.CharacterList)
        //{
        //    _characterInfos.Add(
        //        new CurrentCharacterInfo(character.EntityPrefab, character.Health, character.State)   
        //        );
        //}
    }

    public static void SerializeCurrentInfo()
    {
        SetCharactersInfo();
        TextAsset saveFile = Resources.Load<TextAsset>("Saves/CurrentGroupSave");
        
        var serialized = JsonUtility.ToJson(_characterInfos);
        File.WriteAllText(AssetDatabase.GetAssetPath(saveFile), serialized);
    }

    public static List<CurrentCharacterInfo> DeserializeCurrentInfo()
    {
        TextAsset saveFile = Resources.Load<TextAsset>("Saves/CurrentGroupSave");
        var deserializedString = File.ReadAllText(AssetDatabase.GetAssetPath(saveFile));

        List<CurrentCharacterInfo> deserialized = JsonUtility.FromJson<List<CurrentCharacterInfo>>(deserializedString);
        _characterInfos = deserialized;

        return _characterInfos;
    }
}
