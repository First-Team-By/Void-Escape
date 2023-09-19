using System;
using System.Collections.Generic;

public static class QuestFactory
{
	private static Type[] _questTypes = new Type[3]
	{
		 typeof(KillMonsterQuest),
		 typeof(CollectItemQuest),
		 typeof(RescueQuest)
	};
	
	public static List<Quest> GetQuests()
	{
		var random1 = new Random().Next(0, _questTypes.Length);
		
		int random2;
		do 
		{
			random2 = new Random().Next(0, _questTypes.Length);
		} while (random1 == random2);
		
		return new List<Quest>() 
		{
            (Quest)Activator.CreateInstance(typeof(ExplorationQuest)),
            (Quest)Activator.CreateInstance(_questTypes[random1]), 
			(Quest)Activator.CreateInstance(_questTypes[random2])
		};
	}
}