using System;
using System.Collections.Generic;
using System.Linq;

public class FearingHowl : EntityCommand
{
    public override string IconName {get;}
    public override string EffectName => "effect_fearing_sprite";


    public FearingHowl()
    {
        Name = "Устрашающий вой";
        damage = 0;
        Conditioning.SetFearing(0.3f);
    }

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targets)
    {
        if (selfPosition < 8)
        {
            return new List<EntityInfo>();
        }

        return targets;
    }

    public override List<int> GetSelectedTargets(int targetPosition)
    {
        return new List<int>() { 1, 2, 3, 4, 5 };
    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        foreach (var target in executeInfo.Targets)
        {
            var targetState = AttackResolver.ResolveAttack(damage, executeInfo.Actor, target, Conditioning);
            targetState.Effect = Effect;
            result.TargetStates.Add(target.Position, targetState);
        }

        result.ActorPoseName = PosesConst.Scream;

        return result;
    }

}

