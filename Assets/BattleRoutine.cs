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
    [SerializeField] private GameObject officerPrefab;


    public int roundCounter { get; private set; }

    private DepartmentLevel level;
    private List<Enemy> enemyList;
    private Queue<EntityBase> turnQueue;

    private CharacterGroup group;
    
    public UnityEvent<EntityBase> OnEntityTurn;

    private void InitBattle()
    {
        turnQueue = new Queue<EntityBase>();
        roundCounter = 1;
        group = Global.currentGroup;
        foreach (var character in group.CharacterList)
        {
            character.transform.SetParent(characterPositions[character.Position - 1].transform); 
            character.transform.localPosition = Vector2.zero;
        }

        SetLevel();
        InitQueue();
        EntityTurn();
    }


    private void EntityTurn()
    {
        if (turnQueue.Count == 0)
        {
            InitQueue();
        }
        var currentEntity = turnQueue.Dequeue();
        
        OnEntityTurn?.Invoke(currentEntity);
    }

    private void InitQueue()
    {
        foreach (var character in group.CharacterList)
        {
            turnQueue.Enqueue(character);
        }

        foreach (var enemy in level.EnemyList)
        {
            turnQueue.Enqueue(enemy);
        }
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

    void Start()
    {
        InitBattle();
    }

    void Awake()
    {
        Global.currentGroup = new CharacterGroup();
        Global.currentGroup.CharacterList = new List<Character>();
        var officer = Instantiate(officerPrefab);
        officer.GetComponent<Officer>().Position = 1;

        Global.currentGroup.CharacterList.Add(officer.GetComponent<Officer>());

    }

}
