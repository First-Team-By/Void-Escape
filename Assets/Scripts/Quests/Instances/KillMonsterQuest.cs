using System;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class KillMonsterQuest : Quest
{
	private int monstersAmount = 1;
	private string _description;
	public Type monsterType {get; set;}
	public override string Title => "Убийство монстров";
	public override string Description => _description;
	public override QuestType Type { get; set; }

	public override void Initialize(MapInfo mapInfo)
	{
		if (monsterType == null)
		{
			Debug.LogError("Boss is undefined");
			return;
		}
		
		var boss = (EnemyInfo)Activator.CreateInstance(monsterType);
		var roomNumber = GetGoalRoom(mapInfo);
		
		_description = $"Убейте монстра {boss.ClassName}";
		
		boss.HealthOver += OnBossHealthOver;
		mapInfo.AddBoss(roomNumber, boss);
	}
	
	private void OnBossHealthOver(EntityInfo entity)
	{
		QuestComplete();
	}
}
