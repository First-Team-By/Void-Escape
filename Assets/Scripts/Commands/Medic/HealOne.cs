using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealOne : CharacterCommand
{
    private float healthAddition = 10;
    public HealOne()
    {
        IsEnabled = HealOneEnabled;

        SelfPositions = new List<int>() { 4, 5 };

        Name = "Heal one";
    }

    public override string IconName => "healonecommand_sprite";
    public override string EffectName => "healoneeffect_sprite";
    public override List<int> GetAvaliableTargets(int selfPosition, List<int> targetPositions)
    {
        return targetPositions.Where(x => x < 6).ToList();
    }

    public override List<int> GetSelectedTargets(int targetPosition)
    {
        return base.GetSelectedTargets(targetPosition);
    }

    private bool HealOneEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

    public override CommandResult Execute(EntityBase actor, IEnumerable<EntityBase> targets)
    {
        var result = new CommandResult();
        var target = targets.GetEnumerator().Current;
        result.TargetStates.Add(target.Position, target.GetHealth(healthAddition, Effect));
        result.Actor = actor;
        result.ActorPose = EntityPose.AttackPose;

        return result;
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        //if (entity is Character)
        //{
        //    return (entity as Character).Weapon.Type == WeaponType.Pistol;
        //}

        return true;
    }
}
