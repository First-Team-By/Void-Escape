using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityTool : MonoBehaviour
{
    public abstract List<EntityCommand> Commands { get; }
}