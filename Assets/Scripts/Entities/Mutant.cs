﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : Enemy
{
    public override List<EntityCommand> Commands()
    {
        return new List<EntityCommand>() { new ClawStrike() };
    }
}