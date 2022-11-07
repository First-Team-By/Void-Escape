using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityCommand
{
    public Sprite Icon { set; get; }
    public Action OnExecute { set; get; }
    public Predicate<EntityBase> IsEnabled { set; get; }

    public List<int> SelfPositions { set; get; }
    public List<int> EnemyPositions { set; get; }
}