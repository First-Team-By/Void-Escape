using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommandExecuteInfo
{
	public EntityInfo Actor { get; set; }
	public List<EntityInfo> Targets { get;set; }
	public BattlePosition[] CharacterPositions { get; set; }
	public BattlePosition[] EnemyPositions { get;set; }
	
}
