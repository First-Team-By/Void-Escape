using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class Global
{
    public static CharacterGroup currentGroup;

    public static List<GameObject> enemyPrefabs;

    private static GameObject enemyPrefabContainer;
    private static GameObject characterPrefabContainer;

    public static CharacterPrefabs CharacterPrefabs { get; set; }

    static Global()
    {
        enemyPrefabContainer = Resources.Load<GameObject>("EnemyPrefabs");
        enemyPrefabs = enemyPrefabContainer.GetComponent<EnemyPrefabs>().EnemyList;
        currentGroup = new CharacterGroup();

        characterPrefabContainer = Resources.Load<GameObject>("CharacterPrefabs");
        CharacterPrefabs = characterPrefabContainer.GetComponent<CharacterPrefabs>();
    }

    public static void SaveCharactersInfo(List<Character> characters)
    {
        currentGroup.CurrentCharacterInfos.Clear();
        foreach (var character in characters)
        {
            currentGroup.CurrentCharacterInfos.Add(new CurrentCharacterInfo(character));
        }
    }
}
