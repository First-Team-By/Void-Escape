using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    [SerializeField] private GameObject[] enemyPositions;
    [SerializeField] private Image characterImage;
    [SerializeField] private CommandExecutionHandler commandExecutor;
    [SerializeField] private UIActionPanel actionPanel;
    public int roundCounter { get; private set; }
    public List<EntityBase> EntitiesRoute => EnemyList
        .Cast<EntityBase>()
        .Concat(characterList)
        .OrderByDescending(i => i.CurrentInitiative)
        .ToList();

    public List<GameObject> AllPositions => characterPositions.Concat(enemyPositions).ToList();


    private DepartmentLevel level;
    public List<Enemy> EnemyList => level.EnemyList;
    private List<Character> characterList;
    private List<EntityBase> inactiveEntitiesList = new List<EntityBase>();
    private EntityBase currentEntity;

    private CharacterGroup group;
    
    public EntityCommand CurrentCommand { get; set; }
    public List<int> CurrentAvaliableTargets { get; set; }
    public List<int> CurrentSelectedTargets { get; set; }

    private EntityBase CurrentEntity
    {
        get
        {
            return currentEntity;
        }
        set
        {
            currentEntity = value;
            if (currentEntity != null)
            {
                characterImage.sprite = currentEntity.Portrait;
            }
        }
    }


    private void InitBattle()
    {
        roundCounter = 1;
        SetCharactersInPositions();
        SetLevel();
        NextEntityTurn();
    }

    private void MainBattleProcess()
    {
        CurrentEntity = EntitiesRoute.FirstOrDefault(x => !inactiveEntitiesList.Contains(x));
        if (currentEntity is null)
        {
            NextRound();
        }

        NextEntityTurn();
    }

    private void NextEntityTurn()
    {
        OnEntityTurn();
    }

    private void NextRound()
    {
        inactiveEntitiesList.Clear();
        CheckBattleResult();
    }

    private void OnEntityTurn()
    {
        if (currentEntity is Character)
        {
            commandExecutor.SetCommands(currentEntity);
            CurrentCommand = null;
            CurrentAvaliableTargets = null;
        }
        else
        {
            inactiveEntitiesList.Add(currentEntity);
            MainBattleProcess();
        }
    }
    
    private void SetLevel()
    {
        level = new DepartmentLevel(5, 5);
        SetEnemiesInPositions();
    }
    private void SetEnemiesInPositions()
    {
        for (int i = 0; i < level.EnemyList.Count; i++)
        {
            level.EnemyList[i].transform.SetParent(enemyPositions[i].transform);
            level.EnemyList[i].transform.localPosition = Vector2.zero;
            level.EnemyList[i].Position = i + 6;
        }
    }

    private void SetCharactersInPositions()
    {
        group = Global.currentGroup;
        foreach (var character in group.CurrentCharacterInfos)
        {
            var characterInst = Instantiate(character.CharacterPrefab, characterPositions[character.Position - 1].transform);
            characterInst.GetComponent<SpriteRenderer>().sortingOrder = character.Position;
            characterInst.transform.localPosition = Vector2.zero;
            //characterInst.transform.localScale = Vector2.one;
            var _characterInst = characterInst.GetComponent<Character>();
            _characterInst.Position = character.Position;
            characterList.Add(_characterInst);
        }
    }

    public void SetCurrentCommand(EntityCommand command)
    {
        CurrentAvaliableTargets = command.GetAvaliableTargets(currentEntity.Position, EntitiesRoute.Select(x => x.Position).ToList());
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
            actionPanel.ShowCommandResult(CurrentCommand.Execute(currentEntity, selectedTargets));
        }
        
        CheckBattleResult();
        DeSelectTargets();
        inactiveEntitiesList.Add(CurrentEntity);
    }

    private void CheckBattleResult()
    {
        if (!characterList.Any())
        {
            LoseBattle();   
        }

        if (!EnemyList.Any())
        {
            WinBattle();
        }
    }

    private void WinBattle()
    {

    }

    private void LoseBattle()
    {

    }

    void Start()
    {
        characterList = new List<Character>();
        InitBattle();
    }

    void Awake()
    {
        actionPanel.ActionEnd += ClearSelectedTargets;
        actionPanel.ActionEnd += MainBattleProcess;
    }

}
