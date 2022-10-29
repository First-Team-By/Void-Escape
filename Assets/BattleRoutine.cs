using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class BattleRoutine : MonoBehaviour
{
    public List<Character> characters => gameObject.GetComponentsInChildren<Character>().ToList();
    public List<Enemy> enemies => gameObject.GetComponentsInChildren<Enemy>().ToList();

    private Queue<EntityBase> turnQueue;

    public int roundCounter { get; private set; }

    private void Init()
    {
        roundCounter = 1;
        turnQueue = new Queue<EntityBase>();
    }

    private void InitQueue()
    {
        foreach (var character in characters)
        {
            turnQueue.Enqueue(character);
        }

        foreach (var enemy in enemies)
        {
            turnQueue.Enqueue(enemy);
        }
    }

    private void EntityTurn()
    {
        if (turnQueue.Count == 0)
        {
            InitQueue();
        }
    }

    void Start()
    {
        Init();


    }
}
