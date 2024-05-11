using Assets.Scripts.Entities.Resources;
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
	public static GameStage Stage = GameStage.StartNewGame;
	public static List<CharsTemplate> AllCharacterClasses;
	public static List<CharsTemplate> AllEnemiesClasses;
	public static HibernationCapsuleInfo[] Capsules;
	public static List<Compartment> Compartments;

	public static CurrentCharacterGroup CurrentGroup;

	public static CharacterGroup AllCharacters;
	public static List<CharsTemplate> generableCharacterClasses 
	{ 
		get
		{
			return AllCharacterClasses.Where(x => x.EntityChars.IsGenerable).ToList();
		}
	}

	public static MapInfo CurrentMapInfo;

	public static Inventory inventory;
	public static Storage Storage { get; set; }

	public static CommonPrefabs CommonPrefabs { get; }

	public static bool UIIntersect { get; set; } = false;

	public static List<CharsTemplate> AllEntityTemplates { get; set; }

	public static Dictionary<string, Sprite> ResourceImages;
	static Global()
	{
		Storage = new Storage();
		Storage.Resources.Energy = 1000;
		inventory = new Inventory();
		
		CommonPrefabs = Resources.Load<GameObject>("CommonPrefabs").GetComponent<CommonPrefabs>();

        ResourceImages = new Dictionary<string, Sprite>() {
            {"energy", Resources.Load<Sprite>("Sprites/UI/resource_energy_sprite")},
            {"medicine", Resources.Load<Sprite>("Sprites/UI/resource_meds_sprite")},
            {"metal", Resources.Load<Sprite>("Sprites/UI/resource_metall_sprite")},
            {"electronics", Resources.Load<Sprite>("Sprites/UI/resource_electronics_sprite")},
        };

        CurrentGroup = new CurrentCharacterGroup();

		AllCharacters = new CharacterGroup();
		//allCharacters.CharacterInfos.AddRange(new List<CharacterInfo>() {
		//     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Officer, 1),
		//     CharacterFactory.CreateCharacterInfo(CharacterPrefabs.Medic, 2)
		//     });

		Capsules = new HibernationCapsuleInfo[] { new HibernationCapsuleInfo(), new HibernationCapsuleInfo(), 
			new HibernationCapsuleInfo(){ Status = CapsuleStatus.UnPlugged} };
		
		LoadCharTemplates();

		Compartments = new List<Compartment>() { new LowerDecks(), new ReactorChamber() };
		
		CreatePreConditions();
	}

	public static RoomInfo GetCurrentRoomInfo()
	{
		return CurrentMapInfo.GetCurrentRoomInfo();
	}

	public static void SaveCharactersInfo(List<CharacterInfo> characters)
	{
		CurrentGroup.CurrentCharacterInfos.Clear();
		foreach (var character in characters)
		{
			CurrentGroup.CurrentCharacterInfos.Add(character);
		}
	}

	private static void LoadCharTemplates()
	{
		AllCharacterClasses = new List<CharsTemplate>();
		AllEnemiesClasses = new List<CharsTemplate>();

		LoadCharacterCharTemplate("OfficerChars", typeof(Officer));
		LoadCharacterCharTemplate("MedicChars", typeof(Medic));
		LoadCharacterCharTemplate("JosephSteelsChars", typeof(JosephSteels));
		LoadCharacterCharTemplate("EngineerChars", typeof(CombatEngineer));
		// LoadEnemyCharTemplate("MutantChars", typeof(Mutant));
		// LoadEnemyCharTemplate("MiddleMutant", typeof(Mutant));
		// LoadEnemyCharTemplate("MegaMutant", typeof(Mutant));
		LoadEnemyCharTemplate("MutantBoss", typeof(MutantBoss));
		LoadEnemyCharTemplate("MutantScoutChars", typeof(MutantScout));
		LoadEnemyCharTemplate("MutantBeaterChars", typeof(MutantBeater));

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
	
	public static void RefreshQuests()
	{
		foreach(var compartment in Compartments)
		{
			compartment.AvaliableQuests = QuestFactory.GetQuests();
		}
	}
	
	public static void CreatePreConditions()
	{
		var josephSteels = AllCharacterClasses.FirstOrDefault(x => x.EntityType == typeof(JosephSteels));
		AllCharacters.AddCharacter(EntityFactory.CreateCharacter(josephSteels));
	}
}
