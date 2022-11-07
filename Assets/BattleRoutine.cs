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
        //SetCharacterGroup();
        group = Global.currentGroup;
        foreach (var character in group.CurrentCharacterInfos)
        {
            var characterInst = Instantiate(character.CharacterPrefab, characterPositions[character.Position - 1].transform);
            characterInst.transform.localPosition = Vector2.zero;
            characterInst.transform.localScale = Vector2.one;
        }
    }

    //private void SetCharacterGroup()
    //{
    //    List<CurrentCharacterInfo> characterInfos = CharacterSerializable.DeserializeCurrentInfo();
    //    foreach (var info in characterInfos)
    //    {
    //        var characterInstance = Instantiate(info.CharacterPrefab);
    //        var character = characterInstance.GetComponent<Character>();

    //        character.EntityChars = info.CurrentCharacteristics;
    //        character.Health = info.CurrentHealth;

    //        Global.currentGroup.CharacterList.Add(character);
    //    }
    //}

    void Start()
    {
        InitBattle();
    }

    void Awake()
    {
        
    }

}
