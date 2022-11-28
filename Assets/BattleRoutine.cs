using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    [SerializeField] private GameObject[] enemyPositions;
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
    private EntityBase currentEntity;

    private CharacterGroup group;
    
    public EntityCommand CurrentCommand { get; set; }
    public List<int> CurrentAvaliableTargets { get; set; }
    public List<int> CurrentSelectedTargets { get; set; }
    

    private void InitBattle()
    {
        roundCounter = 1;

        SetCharactersInPositions();
        SetLevel();
        EntityTurn();
    }


    private void EntityTurn()
    {
        currentEntity = EntitiesRoute.First();
        OnEntityTurn();
    }

    private void OnEntityTurn()
    {
        if (currentEntity is Character)
        {
            commandExecutor.SetCommands(currentEntity);
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
            level.EnemyList[i].Position = i + 5;
        }
    }

    private void SetCharactersInPositions()
    {
        group = Global.currentGroup;
        foreach (var character in group.CurrentCharacterInfos)
        {
            var characterInst = Instantiate(character.CharacterPrefab, characterPositions[character.Position - 1].transform);
            characterInst.transform.localPosition = Vector2.zero;
            characterInst.transform.localScale = Vector2.one;
            var _characterInst = characterInst.GetComponent<Character>();
            _characterInst.Position = character.Position;
            characterList.Add(_characterInst);
        }
    }

    public void SetCurrentCommand(EntityCommand command)
    {
        CurrentAvaliableTargets = command.GetAvaliableTargets(currentEntity.Position, EnemyList.Select(x => x.Position).ToList());
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

    public void OnTargetClick()
    {
        var selectedTargets = EnemyList.Where(x => CurrentSelectedTargets.Contains(x.Position));
        
        actionPanel.ShowCommandResult(CurrentCommand.Execute(currentEntity, selectedTargets));
    }

    void Start()
    {
        characterList = new List<Character>();
        InitBattle();
    }

    void Awake()
    {

    }

}
