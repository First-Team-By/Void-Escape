﻿using Assets.Scripts.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public enum GameStage
{
	StartNewGame = 0,
	InMission = 1,
	OnBase = 2,
}
public static class Global
{
	public static GameStage Stage;
	public static List<CharsTemplate> AllCharacterClasses;
	public static List<CharsTemplate> AllEnemiesClasses;
	public static HibernationCapsuleInfo[] capsules;

	public static CurrentCharacterGroup currentGroup;

	public static CharacterGroup allCharacters;

	public static MapInfo currentMapInfo;
	public static Quest currentQuest;

	public static Inventory inventory;
	public static Storage storage { get; set; }

	public static CommonPrefabs CommonPrefabs { get; }
	public static List<Quest> avaliableQuests { get; set; }

	public static bool UIIntersect { get; set; } = false;

	public static List<CharsTemplate> AllEntityTemplates { get; set; }
	static Global()
	{
		storage = new Storage();
		inventory = new Inventory();
		avaliableQuests = new List<Quest>();
		

		CommonPrefabs = Resources.Load<GameObject>("CommonPrefabs").GetComponent<CommonPrefabs>();
		currentGroup = new CurrentCharacterGroup();

		allCharacters = new CharacterGroup();
		//allCharacters.CharacterInfos.AddRange(new List<CharacterInfo>() {
		//     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Officer, 1),
		//     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Medic, 2)
		//     });

		capsules = new HibernationCapsuleInfo[] { new HibernationCapsuleInfo(), new HibernationCapsuleInfo()};

		LoadCharTemplates();
	}

	public static RoomInfo GetCurrentRoomInfo()
	{
		return currentMapInfo.GetCurrentRoomInfo();
	}

	public static void SaveCharactersInfo(List<CharacterInfo> characters)
	{
		currentGroup.CurrentCharacterInfos.Clear();
		foreach (var character in characters)
		{
			currentGroup.CurrentCharacterInfos.Add(character);
		}
	}

	private static void LoadCharTemplates()
	{
		AllCharacterClasses = new List<CharsTemplate>();
		AllEnemiesClasses = new List<CharsTemplate>();

		LoadCharacterCharTemplate("OfficerChars", typeof(Officer));
		LoadCharacterCharTemplate("MedicChars", typeof(Medic));
		LoadEnemyCharTemplate("MutantChars", typeof(Mutant));
		LoadEnemyCharTemplate("MiddleMutant", typeof(Mutant));
		LoadEnemyCharTemplate("MegaMutant", typeof(Mutant));

		AllEntityTemplates = AllEnemiesClasses.Concat(AllCharacterClasses).ToList();
	}

	private static void LoadCharacterCharTemplate(string entityCharName, Type type)
	{
		EntityCharacteristics characteristics = Resources.Load<EntityCharacteristics>("EntityCharacteristics/" + entityCharName);
		AllCharacterClasses.Add(new CharsTemplate(characteristics, type));
	}
	
	private static void LoadEnemyCharTemplate(string entityCharName, Type type)
	{
		EntityCharacteristics characteristics = Resources.Load<EntityCharacteristics>("EntityCharacteristics/" + entityCharName);
		AllEnemiesClasses.Add(new CharsTemplate(characteristics, type));
	}
}
