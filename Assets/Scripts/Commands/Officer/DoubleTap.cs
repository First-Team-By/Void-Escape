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

    public override List<EntityBase> GetAvaliableTargets(int selfPosition, List<EntityBase> targetPositions)
    {
        if (selfPosition > 3)
        {
            return new List<EntityBase>();
        }
        if (selfPosition == 1)
        {
            return targetPositions.Where(x => x.Position == 6 || x.Position == 7 && !x.OnDeathDoor).ToList();
        }
        if (selfPosition == 3)
        {
            return targetPositions.Where(x => x.Position == 7 || x.Position == 8 && !x.OnDeathDoor).ToList();
        }
        
        return targetPositions.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }

    public override CommandResult Execute(EntityBase actor, List<EntityBase> targets)
    {
        var result = new CommandResult();
        foreach (var target in targets)
        {
            result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        }
        result.Actor = actor;
        result.ActorPose = EntityPose.AttackPose;
        
        return result;
    }
}

