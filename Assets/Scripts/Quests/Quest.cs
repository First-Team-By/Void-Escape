using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest
{
    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract QuestType Type { get; set; }
    public Loot Reward { get; }
    public QuestStatus Status { get; set; }
    public void QuestComplete()
    {
        Status = QuestStatus.Completed;
        OnQuestComplete?.Invoke();
    }

    public Action OnQuestComplete;
}
