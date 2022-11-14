using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EntityCommand
{
    public Sprite Icon { set; get; }
    public UnityAction OnExecute { set; get; }
    public Predicate<EntityBase> IsEnabled { set; get; }

    public List<int> SelfPositions { set; get; }
    public List<int> EnemyPositions { set; get; }

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
}