using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapInfo
{
	public List<RoomInfo> RoomInfos;
	public int currentRoomNumber;
	public MissionState missionState;
	public List<CharsTemplate> PossibleEnemies { get; set; }
	public List<LootItemInfo> PossibleLoot { get; set; }
	public Vector2 Size { get; set; }
	public Quest MapQuest { get; set; }
	public RoomInfo GetCurrentRoomInfo()
	{
		return RoomInfos[currentRoomNumber];
	}

	public int GetNormalizedDifficulty(int roomNumber)
	{
		var maxvalue = PossibleEnemies.Max(x => x.EntityChars.Value);
		
		var normalized = (float)roomNumber /
						 (RoomInfos.Count - 1) *
						 maxvalue;

		return Mathf.CeilToInt(normalized);
	}

	public void InitEnemyForRoom(RoomInfo roomInfo)
	{
		roomInfo.InitEnemies(GetNormalizedDifficulty(roomInfo.RoomNumber), PossibleEnemies);
	}

	public void InitLootForRoom(RoomInfo roomInfo)
	{
		roomInfo.CreateLoot(roomInfo.RoomNumber / RoomInfos.Count, PossibleLoot);
	}
	
	public void AddBoss(int roomNumber, EnemyInfo boss)
	{
		var roomInfo = RoomInfos[roomNumber];
		if (roomInfo.EnemyInfos.Count == 5)
		{
			roomInfo.EnemyInfos.RemoveAt(4);
		}
		
		roomInfo.EnemyInfos.Add(boss);
	}
	
	public void AddQuestItem(int roomNumber, LootItem item)
	{
		var roomInfo = RoomInfos[roomNumber];
		roomInfo.Loot.Items.Add(item);
	}
}
