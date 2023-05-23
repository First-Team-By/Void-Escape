using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest
{
    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract QuestDifficulty Difficulty { get; }
    public Loot Reward { get; }
    public bool IsCompleted { get; set; }
    public void QuestComplete()
    {
        IsCompleted = true;
        OnQuestComplete?.Invoke();
    }

    public Action OnQuestComplete;
}
