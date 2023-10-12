using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RescueQuest : Quest
{
	public override string Title => "Спасение человека";

	public override string Description => "Спасти персонажа";

	public override QuestType Type { get; set; }
	public CharsTemplate QuestCharacterTemplate { get; set; }
	private CharacterInfo _questCharacter;
	public int QuestRoomNumber { get; set; }
	public CharacterInfo QuestCharacter => _questCharacter;

	public override void Initialize(MapInfo mapInfo)
	{
		if (QuestCharacterTemplate == null)
		{
			Debug.LogError("Quest person template is undefined");
			return;
		}
		
		_questCharacter = CharacterFactory.CreateCharacter(QuestCharacterTemplate);
		QuestRoomNumber = 1; //GetGoalRoom(mapInfo);
		
		_questCharacter.AddedToTeam += OnAddedToTeam;
	}
	
	private void OnAddedToTeam(CharacterInfo characterInfo)
	{
		QuestComplete();
	}
}
