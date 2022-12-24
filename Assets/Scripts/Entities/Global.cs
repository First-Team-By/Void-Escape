using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class Global
{
    public static CurrentCharacterGroup currentGroup;

    public static CharacterGroup allCharacters;

    public static int currentRoomNumber;

    public static List<GameObject> enemyPrefabs;

    private static GameObject enemyPrefabContainer;

    private static GameObject characterPrefabContainer;

    public static CharacterPrefabs CharacterPrefabs { get; set; }

    static Global()
    {
        enemyPrefabContainer = Resources.Load<GameObject>("EnemyPrefabs");
        enemyPrefabs = enemyPrefabContainer.GetComponent<EnemyPrefabs>().EnemyList;
        currentGroup = new CurrentCharacterGroup();

        characterPrefabContainer = Resources.Load<GameObject>("CharacterPrefabs");
        CharacterPrefabs = characterPrefabContainer.GetComponent<CharacterPrefabs>();
        allCharacters = new CharacterGroup();
        allCharacters.CharacterInfos.AddRange(new List<CharacterInfo>() {
             CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Officer, 1),
             CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Medic, 2)
             });
    }

    //public static void SaveCharactersInfo(List<Character> characters)
    //{
    //    currentGroup.CurrentCharacterInfos.Clear();
    //    foreach (var character in characters)
    //    {
    //        currentGroup.CurrentCharacterInfos.Add(CharacterFactory.CreateCurrentCharacterInfo(character));
    //    }
    //}
}
