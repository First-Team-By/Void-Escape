using System;

public abstract class Quest
{
	public abstract string Title { get; }
	public abstract string Description { get; }
	public abstract QuestType Type { get; set; }
	public Loot Reward { get; }
	public QuestStatus Status { get; set; }
	public Action OnQuestComplete;
	public void QuestComplete()
	{
		Status = QuestStatus.Completed;
		OnQuestComplete?.Invoke();
	}
}
