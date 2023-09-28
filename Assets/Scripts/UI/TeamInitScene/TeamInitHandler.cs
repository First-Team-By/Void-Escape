using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamInitHandler : MonoBehaviour
{
	[SerializeField] private TMP_Text _prizeText1Caption; 
	[SerializeField] private TMP_Text _prizeText2Caption;
	[SerializeField] private ToolTipAppear _toolTip1;
	[SerializeField] private ToolTipAppear _toolTip2;
	[SerializeField] private UIPartyBuildPosition[] characterPositions;
	[SerializeField] private ContainmentController[] _containmentControllers; 
	private Quest _selectedQuest;

	private ContainmentController SelectedController
	{
		get => _containmentControllers.FirstOrDefault(x => x.IsSelected);
	}
	
	private void Start()
	{
		// _containmentControllers = FindObjectsByType<ContainmentController>(FindObjectsSortMode.None);

		foreach (var controller in _containmentControllers)
		{
			controller.Selected += OnContainmentSelected;
		}
	}
	
	private void OnEnable()
	{
		OnContainmentSelected(_containmentControllers[0]);
		SelectQuest(0);
	}
	
	private void OnContainmentSelected(ContainmentController controller)
	{
		var selectedContainment = SelectedController;
		if (selectedContainment != null)
		{
			selectedContainment.Select(false);
		}
		
		controller.Select(true);
		
		_prizeText1Caption.text = controller.Compartment.AvaliableQuests[1].Title;
		_prizeText2Caption.text = controller.Compartment.AvaliableQuests[2].Title;

		_toolTip1.ToolTipString = controller.Compartment.AvaliableQuests[1].Description;
		_toolTip2.ToolTipString = controller.Compartment.AvaliableQuests[2].Description;

	}

	public void SelectQuest(int questIndex)
	{
		_selectedQuest = SelectedController.Compartment.AvaliableQuests[questIndex];
	}
	
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
			throw new InvalidOperationException("The group list is empty");
		}

		Global.SaveCharactersInfo(characters);

		Global.currentMapInfo = new MapInfo()
		{
			Size = new Vector2(5, 5),
			possibleEnemies = Global.AllEnemiesClasses.Where(x => !x.EntityChars.IsQuestEntity).ToList(),
			possibleLoot = new List<LootItemInfo>() { new LootItemInfo(typeof(Pistol), 1f), new LootItemInfo(typeof(Battery), 0.9f) },
			MapQuest = _selectedQuest
		};
		
		Global.currentMapInfo.currentRoomNumber = 0;
		Global.Stage = GameStage.InMission;

		SceneManager.LoadScene(3); // DungeonScene
	}
}
