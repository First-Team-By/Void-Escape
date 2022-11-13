using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPositions;
    [SerializeField] private GameObject[] enemyPositions;


    public int roundCounter { get; private set; }
    public List<EntityBase> EntitiesRoute { get =>  enemyList.Cast<EntityBase>().Concat(characterList).ToList(); }

    private DepartmentLevel level;
    private List<Enemy> enemyList;
    private List<Character> characterList;

    private CharacterGroup group;
    
    public UnityEvent<EntityBase> OnEntityTurn;

    private void InitBattle()
    {
        roundCounter = 1;
        
        SetCharactersInPositions();
        SetLevel();
        EntityTurn();
    }


    private void EntityTurn()
    {
        
    }
    
    private void SetLevel()
    {
        level = new DepartmentLevel(5 ,5);
        SetEnemiesInPositions();
    }
    private void SetEnemiesInPositions()
    {
        for (int i = 0; i < level.EnemyList.Count; i++)
        {
            level.EnemyList[i].transform.SetParent(enemyPositions[i].transform);
            level.EnemyList[i].transform.localPosition = Vector2.zero;
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
            characterList.Add(characterInst.GetComponent<Character>());
        }
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
