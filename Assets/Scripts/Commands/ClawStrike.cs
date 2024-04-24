﻿using System.Collections.Generic;
using System.Linq;

public class ClawStrike : EntityCommand
{
    public override string EffectName => "effect_slash_sprite";
    public override string IconName { get; }
    public ClawStrike()
    {
        damage = 5;

        Name = "Удар когтями";

        //SelfPositions = new List<int>() { 6, 7, 8 };
        //EnemyPositions = new List<int>() { 1, 2, 3 };
    }

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targets)
    {
        if (selfPosition > 8)
        {
            return new List<EntityInfo>();
        }
        if (selfPosition == 6)
        {
            return targets.Where(x => x.Position == 1 || x.Position == 2 && !x.OnDeathDoor).ToList();
        }
        if (selfPosition == 8)
        {
            return targets.Where(x => x.Position == 2 || x.Position == 3 && !x.OnDeathDoor).ToList();
        }

        return targets.Where(x => x.Position < 4 && !x.OnDeathDoor).ToList();
    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        var target = executeInfo.Targets.FirstOrDefault();

        var targetState = AttackResolver.ResolveAttack(damage, executeInfo.Actor, target, Conditioning);
        targetState.Effect = Effect;
        result.TargetStates.Add(target.Position, targetState);
        result.ActorPoseName = PosesConst.ClawStrike;

        return result;
    }

    //public bool IsEnabled(EntityInfo entity, List<CharacterInfo> possibleTargets)
    //{
    //    return GetAvaliableTargets(entity.Position, possibleTargets.Select(x => x as EntityInfo).ToList()).Any();
    //}
}