using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class Global
{
    public static HibernateCapsule[] capsules;

    public static List<GameObject> availableClasses;

    public static CurrentCharacterGroup currentGroup;

    public static CharacterGroup allCharacters;

    public static MapInfo currentMapInfo;

    private static GameObject enemyPrefabContainer;

    private static GameObject characterPrefabContainer;

    public static CharacterPrefabs CharacterPrefabs { get; }
    public static EnemyPrefabs EnemyPrefabs { get; }

    static Global()
    {
        enemyPrefabContainer = Resources.Load<GameObject>("EnemyPrefabs");
        EnemyPrefabs = enemyPrefabContainer.GetComponent<EnemyPrefabs>();
        currentGroup = new CurrentCharacterGroup();

        characterPrefabContainer = Resources.Load<GameObject>("CharacterPrefabs");
        CharacterPrefabs = characterPrefabContainer.GetComponent<CharacterPrefabs>();
        allCharacters = new CharacterGroup();
        //allCharacters.CharacterInfos.AddRange(new List<CharacterInfo>() {
        //     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Officer, 1),
        //     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Medic, 2)
        //     });

        availableClasses = new List<GameObject>()
        {
            CharacterPrefabs.Officer,
            CharacterPrefabs.Medic
        };

        capsules = new HibernateCapsule[] { new HibernateCapsule(), new HibernateCapsule()};
    }

    public static RoomInfo GetCurrentRoomInfo()
    {
        return currentMapInfo.GetCurrentRoomInfo();
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
