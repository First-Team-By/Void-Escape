﻿using System;
using System.Collections;
using System.Collections.Generic;
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

    private bool DoupleTapEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

}

