﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SingleFire : CharacterCommand
{
    public override string IconName => "Officer/command_singlefire_sprite";
    public override string EffectName => "effect_singlefire_sprite";
    public SingleFire() : base()
    {
        damage = 15;
        OnExecute = SingleFireExec;
        IsEnabled = SingleFireEnabled;

        SelfPositions = new List<int>() { 1, 2, 3 };
        EnemyPositions = new List<int>() { 1, 2, 3 };

        Name = "<size=30><color=#ffa500ff>Одиночный выстрел</color></size>";

        Description = "\n<color=#0000ffff>(Персонаж обязан находиться во второй линии.)</color>\nНаносит урон по любому противнику из первого\nряда.";

        FullDescription = Name + "\n" + Description;

        Conditioning.SetBleeding(1f, 2, 3);
        Conditioning.SetPoisoning(1f, 2, 1);
        Conditioning.SetBurning(1f, 4, 1);
    }



    private void SingleFireExec()
    {
        
    }

    private bool SingleFireEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

    public override bool IsAvaliable(EntityInfo entity)
    {
        if (entity is CharacterInfo)
        {
            return (entity as CharacterInfo).Weapon != null && (entity as CharacterInfo).Weapon.Type == WeaponType.Pistol;
        }

        return true;
    }

    public override List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        if (selfPosition < 4)
        {
            return new List<EntityInfo>();
        }

        return targetPositions.Where(x => x.Position < 9 && x.Position > 5 && !x.OnDeathDoor).ToList();
    }

    public override CommandResult Execute(EntityInfo actor, List<EntityInfo> targets)
    {
        var result = new CommandResult();
        var target = targets.FirstOrDefault();
        result.TargetStates.Add(target.Position, target.TakeDamage(damage, actor.EntityChars, Effect, Conditioning));
        result.Actor = actor;
        result.ActorPoseName = Poses.PistolFire;

        return result;
    }

    //public override List<int> GetSelectedTargets(int targetPosition)
    //{
    //    if (targetPosition == 6)
    //    {
    //        return new List<int>() { 6, 9 };
    //    }
    //    if (targetPosition == 8)
    //    {
    //        return new List<int>() { 8, 10 };
    //    }

    //    return new List<int>() { 7 };
    //}

    
}
