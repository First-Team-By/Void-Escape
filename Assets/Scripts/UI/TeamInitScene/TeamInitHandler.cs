using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamInitHandler : MonoBehaviour
{
    [SerializeField] private UIPartyBuildPosition[] characterPositions;
    public void SetTeam()
    {

        List<CharacterInfo> characters = new List<CharacterInfo>();
        for (int i = 0; i < characterPositions.Length; i++)
        {
            CharacterInfo character = characterPositions[i].Character;
            if (character != null)
            {
                character.Position = characterPositions[i].Position;
                characters.Add(character);
            }
        }

        if (characters.Count == 0)
        {
            throw new InvalidOperationException("The group is null or fuck you");
        }

        Global.SaveCharactersInfo(characters);

        Global.currentMapInfo = new MapInfo()
        {
            Size = new Vector2(5, 5),
            possibleEnemies = Global.AllEnemiesClasses,
            possibleLoot = new List<LootItemInfo>() { new LootItemInfo(typeof(Pistol), 1f), new LootItemInfo(typeof(Battery), 0.9f) }
        };

        Global.currentMapInfo.currentRoomNumber = 0;
        SceneManager.LoadScene("DungeonScene");
    }
}
