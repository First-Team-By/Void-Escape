using System;
using System.Collections.Generic;
using System.Linq;

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
			CreateQuest(typeof(ExplorationQuest)),
			CreateQuest(_questTypes[random1]),
			CreateQuest(_questTypes[random2])
		};
	}
	
	private static Quest CreateQuest(Type type)
	{
		var result = Activator.CreateInstance(type);
		
		if (result is KillMonsterQuest)
		{
			((KillMonsterQuest)result).monsterType = typeof(MutantBoss);
		}
		
		if (result is CollectItemQuest)
		{
			((CollectItemQuest)result).ItemType = typeof(LaserPistol);
		}
		
		if (result is RescueQuest)
		{
			((RescueQuest)result).QuestCharacterTemplate = Global.AllEntityTemplates.FirstOrDefault(x => x.EntityChars.EntityClass == EntityClass.JosephSteels);
		}
		
		return result as Quest;
	}
}