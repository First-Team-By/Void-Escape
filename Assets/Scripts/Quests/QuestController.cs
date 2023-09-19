using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class QuestController : MonoBehaviour
{
    [SerializeField] private UIQuestButton expiditionQuestButton;
    [SerializeField] private UIQuestButton purificationQuestButton;

    private List<Type> QuestTypes = new List<Type>()
    {
        typeof(KillMonsterQuest),
        typeof(CollectItemQuest),
        typeof(ExplorationQuest),
    };

    public void AcceptQuest()
    {
        //if (expiditionQuestButton.enabled)
        //{
        //    Global.currentQuest = expiditionQuestButton.Quest;
        //    return;
        //}

        //if (purificationQuestButton.enabled)
        //{
        //    Global.currentQuest = expiditionQuestButton.Quest;
        //    return;
        //}

        Debug.Log("Выбран квест: " + Global.currentQuest.Title);
    }
}
