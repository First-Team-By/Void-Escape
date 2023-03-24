using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Coagulator : CharacterCommand
{
    public Coagulator()
    {
        IsEnabled = CoagulatorEnabled;

        SelfPositions = new List<int>() { 4, 5 };

        Name = "<size=30><color=#ffa500ff>Коагулятор</color></size>";

        Description = "\nСнимает <color=#ff0000ff>Кровотечение</color>";

        FullDescription = Name + "\n" + Description;
    }
    public override string IconName => "coagulatorcommand_sprite";
    public override string EffectName => "coagulatoreffect_sprite";
    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        var result = new CommandResult();
        var target = targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.StopBleeding(Effect));
        result.Actor = actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.Buffing;

        return result;
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        return true;
    }

    public override List<EntityBase> GetAvaliableTargets(int selfPosition, List<EntityBase> targetPositions)
    {
        return targetPositions.Where(x => x.Position < 6 && x.Conditions.IsBleeding).ToList();
    }

    private bool CoagulatorEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }
}
