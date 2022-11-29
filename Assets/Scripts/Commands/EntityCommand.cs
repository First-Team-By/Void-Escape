﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EntityCommand
{
    public string Name { get; set; }
    public abstract string IconName { get; }
    public Sprite Icon { set; get; }
    public Sprite Effect { set; get; }
    public abstract string EffectName { get; }
    public UnityAction OnExecute { set; get; }
    public Predicate<EntityBase> IsEnabled { set; get; }

    public List<int> SelfPositions { set; get; }
    public List<int> EnemyPositions { set; get; }
    

    public EntityCommand()
    {
        Icon = Resources.Load<Sprite>("Sprites/" + IconName);
        Effect = Resources.Load<Sprite>("Sprites/" + EffectName);
    }

    public IEnumerator<EntityBase> GetAccessibleEntities(List<EntityBase> entityList)
    {
        foreach (var entity in entityList)
        {
            if (EnemyPositions.Contains(entity.Position))
            {
                yield return entity;
            }
        }
    }

    public virtual List<int> GetAvaliableTargets(int selfPosition, List<int> targetPositions)
    {
        return new List<int>();
    }

    public virtual List<int> GetSelectedTargets(int targetPosition)
    {
        return new List<int>() { targetPosition };
    }

    public abstract CommandResult Execute(EntityBase actor, IEnumerable<EntityBase> targets);
}