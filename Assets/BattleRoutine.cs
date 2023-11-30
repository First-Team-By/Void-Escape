using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRoutine : MonoBehaviour
{
	[SerializeField] private BattlePosition[] characterPositions;
	[SerializeField] private BattlePosition[] enemyPositions;
	[SerializeField] private CommandExecutionHandler commandExecutor;
	[SerializeField] private UIActionPanel actionPanel;
	[SerializeField] private EntityBattleCard battleCard;
	[SerializeField] private UIBattleResultCard resultCard;
	public int roundCounter { get; private set; }
	public List<EntityInfo> EntitiesRoute => EnemyList
		.Cast<EntityInfo>()
		.Concat(CharacterList)
		.OrderByDescending(i => i.CurrentInitiative)
		.ToList();

	public List<BattlePosition> AllPositions => characterPositions.Concat(enemyPositions).ToList();
	public RoomInfo currentRoomInfo => Global.GetCurrentRoomInfo();

	private List<EnemyInfo> EnemyList { get; } = new List<EnemyInfo>();
	private List<CharacterInfo> CharacterList { get; } = new List<CharacterInfo>();

    private List<EntityInfo> inactiveEntitiesList = new List<EntityInfo>();
	private EntityInfo currentEntity;

	private CurrentCharacterGroup group;

	private EntityCommand CurrentCommand { get; set; }
	public List<int> CurrentAvaliableTargets { get; set; }
	public List<int> CurrentSelectedTargets { get; set; }

	private bool IsCharacterTurn => CurrentEntity != null && CurrentEntity is CharacterInfo;
	private bool isTurnProcessing;
	private bool isBattleEnded;
	
	private EntityInfo CurrentEntity
	{
		get => currentEntity;
		set => currentEntity = value;
	}

	private void RefreshEntitiesImages()
	{
		foreach(var position in AllPositions)
		{
			position.entityContainer?.RefreshImage();
		}
	}

	private void InitBattle()
	{
		roundCounter = 1;
		SetCharactersInPositions();
		SetEnemiesInPositions();
	}

	private void Update()
	{
		if (!isTurnProcessing)
		{
			MainBattleProcess();
		}
	}

	

	private void MainBattleProcess()
	{
		RefreshHealthBars();
		RefreshEntitiesImages();

        CurrentEntity = EntitiesRoute.FirstOrDefault(x => IsActive(x));

		if (CurrentEntity is null)
		{
			NextRound();
		}
		else
		{
			SetBattlePositionOn();
			battleCard.FillInfo(CurrentEntity);
		}

		OnEntityTurn();

	}

	public void SkipTurn()
	{
		if (CurrentEntity != null)
		{
			inactiveEntitiesList.Add(CurrentEntity);
		}
		isTurnProcessing = false;
	}


	private void NextRound()
	{
		inactiveEntitiesList.Clear();
		RefreshConditions();
	}

	private void OnEntityTurn()
	{

		if (CurrentEntity != null)
		{
			isTurnProcessing = true;
			var conditionsResult = CurrentEntity.ProcessConditions();
			StartCoroutine(conditionsProcess(conditionsResult, CurrentEntity.Position));
			RefreshHealthBars();
		}

		if (CurrentEntity is CharacterInfo)
		{
			commandExecutor.SetCommands(currentEntity);
		}
		else
		{
			if (CurrentEntity != null)
			{
				var enemy = CurrentEntity as EnemyInfo;
				if (enemy != null)
				{
					var executeInfo = new BattleCommandExecuteInfo()
					{
						Actor = currentEntity,
						AlliesPositions = enemyPositions,
						EnemyPositions = characterPositions
					};
					var result = enemy.Act(executeInfo, CharacterList);
					ShowCommandResult(result);
				}
				//StartCoroutine(Wait1Sec());
				inactiveEntitiesList.Add(currentEntity);

				//isTurnProcessing = false;
			}
		}
	}

	private void SetEnemiesInPositions()
	{
		List<EnemyInfo> enemyInfos = Global.GetCurrentRoomInfo().EnemyInfos;
		for (int i = 0; i < enemyInfos.Count; i++)
		{
			var enemy = CharacterFactory.CreateEntity(enemyInfos[i], enemyPositions[i].gameObject);
            enemyPositions[i].entityContainer = enemy;

            enemy.EntityInfo.Position = i + 6;
			enemy.EntityInfo.HealthOver += OnHealthOver;
			EnemyList.Add((EnemyInfo)enemy.EntityInfo);
		}
	}

	private IEnumerator conditionsProcess(List<TargetState> states, int position)
	{
		var battlePosition = GetBattlePosition(position);
		foreach (var state in states)
		{
			if (state.HealthChanged != 0)
				battlePosition.ShowConditionHealthChanging(state.HealthChanged, state.ConditionName);
			yield return new WaitForSeconds(1.5f);
		}
		battlePosition.ClearCondition();
	}
	private void OnHealthOver(EntityInfo entity)
	{
		CheckBattleResult();
	}

	private bool IsActive(EntityInfo entity)
	{
		return !(entity.OnDeathDoor || inactiveEntitiesList.Contains(entity));
	}

	private void SetCharactersInPositions()
	{
		group = Global.currentGroup;
		foreach (var character in group.CurrentCharacterInfos)
		{
			var characterInstance = CharacterFactory.CreateEntity(character, characterPositions[character.Position - 1].gameObject);
            characterPositions[character.Position - 1].entityContainer = characterInstance;

            characterInstance.GetComponent<SpriteRenderer>().sortingOrder = character.Position;
			CharacterList.Add(character);
			character.HealthOver += OnHealthOver;
		}
	}

	public void SetCurrentCommand(EntityCommand command)
	{
		CurrentAvaliableTargets = command.GetAvaliableTargets(currentEntity.Position, EntitiesRoute).Select(x => x.Position).ToList();
		CurrentCommand = command;
	}

	public void SelectTargets(int targetPosition)
	{
		if (!CurrentAvaliableTargets.Contains(targetPosition))
		{
			return;
		}

		CurrentSelectedTargets = CurrentCommand.GetSelectedTargets(targetPosition);
		foreach (var position in AllPositions)
		{
			var bp = position.GetComponent<BattlePosition>();
			if (CurrentSelectedTargets.Contains(bp.Position))
			{
				bp.LightOn();
			}
		}
	}

	private BattlePosition GetBattlePosition(EntityInfo entity)
	{
		var position = entity.Position;
		return GetBattlePosition(position);
	}

	private BattlePosition GetBattlePosition(int position)
	{
		var battlePosition = position > 5 ? enemyPositions[position - 6] : characterPositions[position - 1];
		return battlePosition.GetComponent<BattlePosition>();
	}

	private void SetBattlePositionOn()
	{
		foreach (var enemyPosition in enemyPositions)
		{
			enemyPosition.GetComponent<BattlePosition>().Show(false);
		}

		foreach (var characterPosition in characterPositions)
		{
			characterPosition.GetComponent<BattlePosition>().Show(false);
		}

		GetBattlePosition(CurrentEntity).Show(true);
	}
	public void DeSelectTargets()
	{
		foreach (var position in AllPositions)
		{
			var bp = position.GetComponent<BattlePosition>();
			bp.LightOff();
		}
	}

	public void ClearSelectedTargets()
	{
		CurrentSelectedTargets = new List<int>();
	}

	public void OnTargetClick()
	{
		var selectedTargets = EntitiesRoute.Where(x => CurrentSelectedTargets.Contains(x.Position)).ToList();

		if (selectedTargets.Any())
		{
			var executeInfo = new BattleCommandExecuteInfo() 
			{ 
				Actor = currentEntity, 
				Targets = selectedTargets, 
				AlliesPositions = characterPositions,
				EnemyPositions = enemyPositions 
			};
			
			var commandResult = CurrentCommand.Execute(executeInfo);
			ShowCommandResult(commandResult);
            DeSelectTargets();
			inactiveEntitiesList.Add(CurrentEntity);
			//isTurnProcessing = false;
		}
	}

	private void ShowCommandResult(CommandResult commandResult)
	{
        foreach (var targetState in commandResult.TargetStates)
        {
            targetState.Value.Effect = CurrentCommand.Effect;
        }

        actionPanel.ShowCommandResult(commandResult);
    }

	public void RefreshHealthBars()
	{
		foreach (var entity in EntitiesRoute)
		{
			var position = GetBattlePosition(entity);
			position.SetHealth(entity.Health / entity.EntityChars.MaxHealth);
		}
	}

	public void FillBattleInfo(int position)
	{
		battleCard.FillInfo(EntitiesRoute.FirstOrDefault(x => x.Position == position));
	}
	public void RefreshConditions()
	{
		foreach (var entity in EntitiesRoute)
		{
			var position = GetBattlePosition(entity);
			position.ShowConditions(entity.Conditions);
		}
	}

	private void CheckBattleResult()
	{
		if (isBattleEnded) return;
		
		if (!CharacterList.Any())
		{
			LoseBattle();
			isBattleEnded = true;
		}

		if (!EnemyList.Where(x => !x.OnDeathDoor).Any())
		{
			WinBattle();
			isBattleEnded = true;
		}
	}

	private void WinBattle()
	{
		Global.GetCurrentRoomInfo().EnemyInfos.Clear();
		Global.currentMapInfo.missionState = MissionState.ReturnFromBattle;

		StartCoroutine(ShowResult());

		Global.inventory.AddToInventory(currentRoomInfo.Loot.Items);
		currentRoomInfo.Loot.InvokeTakingToInventory();
		
		var mapQuest = Global.currentMapInfo.MapQuest as RescueQuest;
		if (mapQuest != null && 
		mapQuest.QuestRoomNumber == Global.GetCurrentRoomInfo().RoomNumber)
		{
			Global.allCharacters.AddCharacter(mapQuest.QuestCharacter);
		}
	}
	
	private IEnumerator ShowResult(float seconds = 2)
	{
	   yield return new WaitForSeconds(seconds);
	   resultCard.FillBattleResultInfo(true, currentRoomInfo.Loot);
	}

	private void LoseBattle()
	{

	}

	void Start()
	{		
		CurrentSelectedTargets = new List<int>();
		InitBattle();     
	}

	void Awake()
	{
		actionPanel.ActionEnd += ClearSelectedTargets;
		actionPanel.ActionEnd += () => isTurnProcessing = false;
	}

	public void ReturnToDungeon()
	{
		SceneManager.LoadScene(3); // DungeonScene
	}
}
