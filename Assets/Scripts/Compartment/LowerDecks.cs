using System.Collections.Generic;
using System.Linq;

public class LowerDecks : Compartment
{
	public LowerDecks()
	{
		_avaliableEnemies =
			Global.AllEnemiesClasses.Where(x => x.EntityType.IsSubclassOf(typeof(Mutant)) && !x.EntityChars.IsQuestEntity).ToList();
		
		_avaliableLoot = new List<LootItemInfo>() 
		{
			new LootItemInfo(typeof(Battery), 5),
			new LootItemInfo(typeof(MetalScrap), 10),
			new LootItemInfo(typeof(MedicationSet), 5),
			new LootItemInfo(typeof(Pistol))
		};
	}
}