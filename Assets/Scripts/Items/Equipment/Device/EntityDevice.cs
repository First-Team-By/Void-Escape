using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeviceType
{
    FirstAidKit
}

public abstract class EntityDevice : Equipment
{
    public DeviceType Type { get; set; }
}
