using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : Enemy
{
    public override List<EntityCommand> Commands { get; }

    protected override void Init()
    {
        Name = "Mutant";
    }
}