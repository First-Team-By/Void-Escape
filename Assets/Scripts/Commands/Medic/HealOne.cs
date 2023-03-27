using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealOne : CharacterCommand
{
    private float healthAddition = 100;
    public HealOne()
    {
        IsEnabled = HealOneEnabled;

        SelfPositions = new List<int>() { 4, 5 };

        Name = "<size=30><color=#ffa500ff>�������</color></size>";

        Description = "\n����� ������ ��������\n������� ������ ������";

        FullDescription = Name + "\n" + Description;
    }

    public override string IconName => "healonecommand_sprite";
    public override string EffectName => "healoneeffect_sprite";
    public override List<EntityBase> GetAvaliableTargets(int selfPosition, List<EntityBase> targetPositions)
    {
        return targetPositions.Where(x => x.Position < 6 && !x.OnDeathDoor).ToList();
    }

    public override List<int> GetSelectedTargets(int targetPosition)
    {
        return base.GetSelectedTargets(targetPosition);
    }

    private bool HealOneEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        var result = new CommandResult();
        var target = targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.GetHealth(healthAddition, Effect));
        result.Actor = actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.Buffing;

        return result;
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        if (entity is Character)
        {
            return (entity as Character).Device?.Type == DeviceType.FirstAidKit;
        }

        return true;
    }
}
