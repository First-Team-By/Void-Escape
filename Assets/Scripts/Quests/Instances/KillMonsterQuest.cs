using System;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class KillMonsterQuest : Quest
{
	private int monstersAmount = 1;
	public Type monsterType {get; set;}
	public override string Title => "Убийство монстров";
	public override string Description => "Убейте 5 монстров";
	public override QuestType Type { get; set; }

	public override void Initialize(MapInfo mapInfo)
	{
		if (monsterType == null)
		{
			Debug.LogError("Boss is undefined");
			return;
		}
		
		var boss = (EnemyInfo)Activator.CreateInstance(monsterType);
		var minRoomNumber = mapInfo.RoomInfos.Count / 4 * 3;
		var maxRoomNumber = mapInfo.RoomInfos.Count;
		
		var roomNumber = 1; // Random.Range(minRoomNumber, maxRoomNumber);
		
		boss.HealthOver += OnBossHealthOver;
		mapInfo.AddBoss(roomNumber, boss);
	}
	
	private void OnBossHealthOver(EntityInfo entity)
	{
		QuestComplete();
	}
}
