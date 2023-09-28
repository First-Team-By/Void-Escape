using System;
using System.Linq;
using UnityEngine;

public class CollectItemQuest : Quest
{
	public override string Title => "Нахождение предмета";
	public override string Description => "Найдите предмет";
	public override QuestType Type { get; set; }
	public Type ItemType {get; set;}

	public override void Initialize(MapInfo mapInfo)
	{
		if (ItemType == null)
		{
			Debug.LogError("Quest item is undefined");
			return;
		}
		
		var roomNumber = 1; //GetGoalRoom(mapInfo);
		
		mapInfo.RoomInfos[roomNumber].Loot.TakingToInventory += LootTaken;
		var item = new LootItem(ItemType);
		mapInfo.AddQuestItem(roomNumber, item);
	}
	
	private void LootTaken(Loot loot)
	{
		var questItem = loot.Items.FirstOrDefault(x => x.Type == ItemType);
		
		if (questItem != null)
		{
			QuestComplete();
			loot.TakingToInventory -= LootTaken;
		}
	}
}
