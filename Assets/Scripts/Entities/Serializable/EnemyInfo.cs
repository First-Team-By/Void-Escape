using System;
using System.Collections.Generic;

public abstract class EnemyInfo : EntityInfo
{
	public delegate bool EntityAction(BattleCommandExecuteInfo info, List<CharacterInfo> possibleTargets, out CommandResult result);
	public override List<EntityCommand> Commands => throw new NotImplementedException();
	protected List<EntityAction> Actions = new List<EntityAction>();
	public CommandResult Act(BattleCommandExecuteInfo executeInfo, List<CharacterInfo> possibleTargets)
	{
        foreach (var action in Actions)
		{		
			if (action(executeInfo, possibleTargets, out var result))
				return result;
		}
		return null;
	}
}
