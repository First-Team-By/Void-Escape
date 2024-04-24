using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

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

    protected float damage;

    public List<int> SelfPositions { set; get; }
    public List<int> EnemyPositions { set; get; }

    public Conditioning Conditioning { get; set; }
    public EntityCommand()
    {
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

    public virtual List<EntityInfo> GetAvaliableTargets(int selfPosition, List<EntityInfo> targets)
    {
        return new List<EntityInfo>();
    }

    public virtual List<int> GetSelectedTargets(int targetPosition)
    {
        return new List<int>() { targetPosition };
    }

    public virtual CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        Debug.Log(executeInfo.Actor.ClassName + " использует " + this.Name);
        return new CommandResult() { Actor = executeInfo.Actor };
    }

    protected virtual bool IsCommandEnabled(EntityInfo entity, List<EntityInfo> targets)
    {
        return GetAvaliableTargets(entity.Position, targets).Any();
    }
}