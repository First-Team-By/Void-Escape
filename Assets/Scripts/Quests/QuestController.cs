using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


    private void Start()
    {
        if (Global.avaliableQuests.Count != 0)
        {
            return;
        }

        SetQuest(expiditionQuestButton);
        SetQuest(purificationQuestButton);
    }

    private void SetQuest(UIQuestButton button)
    {
        int rng = new Random().Next(0, QuestTypes.Count - 1);
        Quest quest = (Quest)Activator.CreateInstance(QuestTypes[rng]);
        button.Quest = quest;
        var toolTip = button.GetComponent<ToolTipAppear>();
        toolTip.ToolTipString = quest.Title + "\n\n" + quest.Description;

        Global.avaliableQuests.Add(quest);
    }

    public void AcceptQuest()
    {
        if (expiditionQuestButton.enabled)
        {
            Global.currentQuest = expiditionQuestButton.Quest;
            return;
        }

        if (purificationQuestButton.enabled)
        {
            Global.currentQuest = expiditionQuestButton.Quest;
            return;
        }
    }
}
