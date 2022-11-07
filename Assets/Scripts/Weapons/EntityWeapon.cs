using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWeapon
{
    public abstract List<EntityCommand> Commands { get; }
}
