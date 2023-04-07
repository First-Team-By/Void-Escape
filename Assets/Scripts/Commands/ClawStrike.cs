using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawStrike : EntityCommand
{
    public ClawStrike()
    {
        OnExecute = ClawStrikeExec;
        IsEnabled = ClawStrikeEnabled;

        SelfPositions = new List<int>() { 1, 2, 3 };
        EnemyPositions = new List<int>() { 1, 2, 3 };
    }

    protected virtual void ClawStrikeExec()
    {

    }

    private bool ClawStrikeEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }


    public override string IconName { get; }
    public override string EffectName { get; }

    public override CommandResult Execute(EntityInfo actor, List<EntityInfo> targets)
    {
        throw new System.NotImplementedException();
    }
}