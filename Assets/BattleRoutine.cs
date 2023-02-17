using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    [SerializeField] private GameObject[] enemyPositions;
    [SerializeField] private Image characterImage;
    [SerializeField] private CommandExecutionHandler commandExecutor;
    [SerializeField] private UIActionPanel actionPanel;
    [SerializeField] private EntityBattleCard battleCard;
    public int roundCounter { get; private set; }
    public List<EntityBase> EntitiesRoute => EnemyList
        .Cast<EntityBase>()
        .Concat(characterList)
        .OrderByDescending(i => i.CurrentInitiative)
        .ToList();

    public List<GameObject> AllPositions => characterPositions.Concat(enemyPositions).ToList();


    private DepartmentLevel level;
    public List<Enemy> EnemyList { get; } = new List<Enemy>();
    private List<Character> characterList;
    private List<EntityBase> inactiveEntitiesList = new List<EntityBase>();
    private EntityBase currentEntity;

    private CurrentCharacterGroup group;
    
    public EntityCommand CurrentCommand { get; set; }
    public List<int> CurrentAvaliableTargets { get; set; }
    public List<int> CurrentSelectedTargets { get; set; }

    private bool isCharacterTurn;

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
        SetEnemiesInPositions();
    }

    private void Update()
    {
        if (!isCharacterTurn)
            MainBattleProcess();
    }

    private void MainBattleProcess()
    {
        RefreshConditions();
        RefreshHealthBars();
        CurrentEntity = EntitiesRoute.FirstOrDefault(x => IsActive(x));
        if (CurrentEntity is null)
        {
            NextRound();
        }
        else
        {
            SetBattlePositionOn();
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
        if (CurrentEntity != null)
        {
            var conditionsResult = CurrentEntity.ProcessConditions();
            StartCoroutine(conditionsProcess(conditionsResult, CurrentEntity.Position));
            RefreshHealthBars();
        }

        if (CurrentEntity is Character)
        {
            commandExecutor.SetCommands(currentEntity);
            isCharacterTurn = true;
        }
        else
        {
            isCharacterTurn = false;
            if (CurrentEntity != null)
            {
                inactiveEntitiesList.Add(currentEntity);
            }
        }
    }
    
    private void SetEnemiesInPositions()
    {
        List<EnemyInfo> enemyInfos = Global.GetCurrentRoomInfo().EnemyInfos;
        for (int i = 0; i < enemyInfos.Count; i++)
        {
            var enemy = GameObject.Instantiate(enemyInfos[i].EnemyPrefab).GetComponent<Enemy>();
            enemy.transform.SetParent(enemyPositions[i].transform);
            enemy.transform.localPosition = Vector2.zero;
            enemy.Position = i + 6;
            enemy.HealthOver += OnHealthOver;
            EnemyList.Add(enemy);
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
    private void OnHealthOver(EntityBase entity)
    {
        CheckBattleResult();
    }

    private bool IsActive(EntityBase entity)
    {
        return !(entity.OnDeathDoor || inactiveEntitiesList.Contains(entity));
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
            _characterInst.Health = character.CurrentHealth;
            characterList.Add(_characterInst);
            _characterInst.HealthOver += OnHealthOver;
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

    private BattlePosition GetBattlePosition(EntityBase entity)
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
            actionPanel.ShowCommandResult(CurrentCommand.Execute(currentEntity, selectedTargets));
        }
        
        CheckBattleResult();
        DeSelectTargets();
        inactiveEntitiesList.Add(CurrentEntity);
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
            position.SetConditions(entity.Conditions);
        }
    }

    private void CheckBattleResult()
    {
        if (!characterList.Any())
        {
            LoseBattle();   
        }

        if (!EnemyList.Where(x => !x.OnDeathDoor).Any())
        {
            WinBattle();
        }
    }

    private void WinBattle()
    {
        Global.GetCurrentRoomInfo().EnemyInfos.Clear();
        Global.missionState = MissionState.ReturnFromBattle;
        SceneManager.LoadScene("SceneDungeonGenerator");
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
        actionPanel.ActionEnd += () => isCharacterTurn = false;
    }

}
