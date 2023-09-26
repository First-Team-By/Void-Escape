using System;
using UnityEditor;

public abstract class Quest
{
	public abstract string Title { get; }
	public abstract string Description { get; }
	public abstract QuestType Type { get; set; }
	public Loot Reward { get; }
	public QuestStatus Status { get; set; }
	public event Action<Quest> Completed;
	
	public void QuestComplete()
	{
		Status = QuestStatus.Completed;
		Completed?.Invoke(this);
	}
	
	public abstract void Initialize(MapInfo mapInfo);
}
