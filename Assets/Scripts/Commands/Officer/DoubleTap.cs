﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTap : CharacterCommand
{
    public DoubleTap()
    {
        damage = 10;

        SelfPositions = new List<int>() { 1, 2, 3 };

        Name = "<size=30><color=#ffa500ff>Двойной выстрел</color></size>";

        Description = "\n<color=#0000ffff>(Персонаж обязан находиться в первой линии.)</color>\nНаносит урон одной из двух ближайших целей.";

        FullDescription = Name + "\n" + Description;
    }

    public override bool IsAvaliable(EntityInfo entity)
    {
        if (entity is CharacterInfo)
        {
            return (entity as CharacterInfo).Weapon != null && (entity as CharacterInfo).Weapon.Type == WeaponType.Pistol;
        }

        return true;
    }

    public override string IconName => "doubletap_sprite";
    public override string EffectName => "doubletapeffect_sprite";

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        if (selfPosition > 3)
        {
            return new List<EntityInfo>();
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

    public override CommandResult Execute(EntityInfo actor, List<EntityInfo> targets)
    {
        var result = new CommandResult();
        foreach (var target in targets)
        {
            result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        }
        result.Actor = actor;
        //result.ActorPose = EntityPose.AttackPose;
        result.ActorPoseName = Poses.PistolFire;
        
        return result;
    }
}

