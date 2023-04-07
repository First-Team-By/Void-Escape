using Assets.Scripts.Entities.Serializable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CommandResult
{
    public Dictionary<int, TargetState> TargetStates { get; set; } = new Dictionary<int, TargetState>();
    public string ActorPoseName { get; set; }
    public EntityInfo Actor { get; set; }
}

public class TargetState
{
    public float HealthChanged { get; set; }
    public string PoseName { get; set; }
    public EntityInfo Target { get; set; }
    public Sprite Effect { get; set; }
    public string ConditionName { get; set; }
}

public static class Poses
{
    public const string PistolFire = "PistolFire";
    public const string BladeStab = "BladeStab";
    public const string Buffing = "Buffing";
    public const string Evade = "Evade";
    public const string Suffering = "Suffering";
    public const string Reinforced = "Reinforced";
}

