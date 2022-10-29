using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : EntityCommand
{
    private void Awake()
    {
        OnExecute = DoupleTapExec;
        IsEnabled = DoupleTapEnabled;

        SelfPositions = new List<int>() { 1, 2, 3 };
        EnemyPositions = new List<int>() { 1, 2, 3 };
    }

    protected virtual void DoupleTapExec()
    {

    }

    private bool DoupleTapEnabled(EntityBase entity)
    {
        return SelfPositions.Contains(entity.Position);
    }

}

