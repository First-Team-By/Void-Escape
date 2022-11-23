﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoubleTap : CharacterCommand
{
    public DoubleTap()
    {
        OnExecute = DoupleTapExec;
        IsEnabled = DoupleTapEnabled;

        SelfPositions = new List<int>() { 1, 2, 3 };
        EnemyPositions = new List<int>() { 1, 2, 3 };
    }

    public override bool IsAvaliable(EntityBase entity)
    {
        if (entity is Character)
        {
            return (entity as Character).Weapon.Type == WeaponType.Pistol;
        }

        return true;
    }

    protected virtual void DoupleTapExec()
    {

    }

    public override string IconName => "doubletap_sprite";

    public override List<int> GetAvaliableTargets(int selfPosition, List<int> targetPositions)
    {

        if (selfPosition > 3)
        {
            return new List<int>();
        }
        if (selfPosition == 1)
        {
            return targetPositions.Where(x => x == 1 || x == 2).ToList();
        }
        if (selfPosition == 3)
        {
            return targetPositions.Where(x => x == 2 || x == 3).ToList();
        }
        
        return targetPositions.Where(x => x < 4).ToList();
    }

    private bool DoupleTapEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

}

