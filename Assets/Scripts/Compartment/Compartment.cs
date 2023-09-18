using System.Collections.Generic;

public class Compartment 
{
	private List<Quest> _avaliableQuests;
	protected List<LootItemInfo> _avaliableLoot;
	protected List<CharsTemplate> _avaliableEnemies;
	
	public List<Quest> AvaliableQuests
	{
		get => _avaliableQuests;
		set => _avaliableQuests = value;
	}
}