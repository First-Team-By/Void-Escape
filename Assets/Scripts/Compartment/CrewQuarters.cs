using System.Collections.Generic;
using System.Linq;

public class CrewQuarters : Compartment
{
	public CrewQuarters()
	{
		_avaliableEnemies =
			Global.AllEnemiesClasses.Where(x => x.EntityType == typeof(Mutant)).ToList();
		
		_avaliableLoot = new List<LootItemInfo>() 
		{
			new LootItemInfo(typeof(Battery)),
			new LootItemInfo(typeof(Pistol))
		};
	}
}