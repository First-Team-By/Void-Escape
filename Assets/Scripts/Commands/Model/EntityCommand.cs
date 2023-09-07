using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EntityCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string FullDescription { get; set; }
    public abstract string IconName { get; }
    public Sprite Icon { set; get; }
    public Sprite Effect { set; get; }
    public abstract string EffectName { get; }
    public UnityAction OnExecute { set; get; }
    public Predicate<EntityInfo> IsEnabled { set; get; }

    public List<int> SelfPositions { set; get; }
    public List<int> EnemyPositions { set; get; }

    public Conditioning Conditioning { get; set; }
    public EntityCommand()
    {
        IsEnabled = IsCommandEnabled;

        Icon = Resources.Load<Sprite>("Sprites/Commands/" + IconName);
        Effect = Resources.Load<Sprite>("Sprites/Effects/Commands/" + EffectName);

        Conditioning = new Conditioning();
    }

    public IEnumerator<EntityInfo> GetAccessibleEntities(List<EntityInfo> entityList)
    {
        foreach (var entity in entityList)
        {
            if (EnemyPositions.Contains(entity.Position))
            {
                yield return entity;
            }
        }
    }

    public virtual List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targetPositions)
    {
        return new List<EntityInfo>();
    }

    public virtual List<int> GetSelectedTargets(int targetPosition)
    {
        return new List<int>() { targetPosition };
    }

    public abstract CommandResult Execute(EntityInfo actor, List<EntityInfo> targets);

    protected virtual bool IsCommandEnabled(EntityInfo entity)
    {
        return SelfPositions.Contains(entity.Position);
    }
}