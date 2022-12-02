using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTap : CharacterCommand
{
    private float damage = 10;
    public DoubleTap()
    {

        SelfPositions = new List<int>() { 1, 2, 3 };

        Name = "Double tap";
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        if (entity is Character)
        {
            return (entity as Character).Weapon.Type == WeaponType.Pistol;
        }

        return true;
    }

    public override string IconName => "doubletap_sprite";
    public override string EffectName => "doubletapeffect_sprite";

    public override List<int> GetAvaliableTargets(int selfPosition, List<int> targetPositions)
    {
        if (selfPosition > 3)
        {
            return new List<int>();
        }
        if (selfPosition == 1)
        {
            return targetPositions.Where(x => x == 6 || x == 7).ToList();
        }
        if (selfPosition == 3)
        {
            return targetPositions.Where(x => x == 7 || x == 8).ToList();
        }
        
        return targetPositions.Where(x => x < 9 && x > 5).ToList();
    }

    public override CommandResult Execute(EntityBase actor, IEnumerable<EntityBase> targets)
    {
        var result = new CommandResult();
        foreach (var target in targets)
        {
            result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect));
        }
        result.Actor = actor;
        result.ActorPose = EntityPose.AttackPose;
        
        return result;
    }
}

