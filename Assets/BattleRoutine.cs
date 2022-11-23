using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    [SerializeField] private GameObject[] enemyPositions;
    [SerializeField] private CommandExecutionHandler commandExecutor;
    public int roundCounter { get; private set; }
    public List<EntityBase> EntitiesRoute => EnemyList
        .Cast<EntityBase>()
        .Concat(characterList)
        .OrderByDescending(i => i.CurrentInitiative)
        .ToList();

    private DepartmentLevel level;
    public List<Enemy> EnemyList => level.EnemyList;
    private List<Character> characterList;
    private EntityBase currentEntity;

    private CharacterGroup group;
    
    private EntityCommand currentCommand;
    public List<int> CurrentAvaliableTargets { get; set; }
    

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
            level.EnemyList[i].Position = i;
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

    public void GetAvaliableTargets(EntityCommand command)
    {
        CurrentAvaliableTargets = command.GetAvaliableTargets(currentEntity.Position, EnemyList.Select(x => x.Position).ToList());
    }

    public void OnTargetClick(EntityBase selectedEntity)
    {

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
