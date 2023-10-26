using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReactorChamber : Compartment
{
    public ReactorChamber()
	{
		_avaliableEnemies =
			Global.AllEnemiesClasses.Where(x => x.EntityType == typeof(Mutant)).ToList();
		
		_avaliableLoot = new List<LootItemInfo>() 
		{
			new LootItemInfo(typeof(Battery), 20),
			new LootItemInfo(typeof(ElectricalSpareParts), 3),
			new LootItemInfo(typeof(MetalScrap), 10),
			new LootItemInfo(typeof(Pistol))
		};
	}
}
