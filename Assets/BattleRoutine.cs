using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class BattleRoutine : MonoBehaviour
{
    [SerializeField] private GameObject[] positions;
    [SerializeField] private GameObject officerPrefab;
    
    private Queue<EntityBase> turnQueue;

    public int roundCounter { get; private set; }

    private CharacterGroup group;

    private void Init()
    {
        roundCounter = 1;
        group = Global.currentGroup;
        foreach (var character in group.CharacterList)
        {
            character.transform.SetParent(positions[character.Position - 1].transform); 
            character.transform.localPosition = Vector2.zero;
        }
    }



    private void EntityTurn()
    {
        if (turnQueue.Count == 0)
        {
        }
    }

    void Start()
    {
        Init();
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
