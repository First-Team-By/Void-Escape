using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamInitHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    public void SetTeam()
    {

        //List<Character> characters = new List<Character>();
        //for (int i = 0; i < characterPositions.Length; i++)
        //{
        //    Character character = characterPositions[i].GetComponentInChildren<Character>();
        //    if (character != null)
        //    {
        //        characters.Add(character);
        //    }
        //}

        //if (characters.Count == 0)
        //{
        //    throw new InvalidOperationException("The group is null or fuck you");
        //}

        //Global.SaveCharactersInfo(characters);

        Global.currentMapInfo = new MapInfo()
        {
            Size = new Vector2(5, 5),
            possibleEnemies = Global.AllEnemiesClasses
        };

        Global.currentMapInfo.currentRoomNumber = 0;
        SceneManager.LoadScene("SceneDungeonGenerator");
    }
}
