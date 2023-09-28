using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Loot
{
	public List<LootItem> Items { get; set; } = new List<LootItem>();
	public event Action<Loot> TakingToInventory;
	
	public void InvokeTakingToInventory()
	{
		TakingToInventory?.Invoke(this);
	}
}
