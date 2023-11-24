using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommandExecuteInfo
{
	public EntityInfo Actor { get; set; }
	public List<EntityInfo> Targets { get;set; } = new List<EntityInfo>();
	public BattlePosition[] AlliesPositions { get; set; }
	public BattlePosition[] EnemyPositions { get;set; }
	
}
