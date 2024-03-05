using System.Collections.Generic;
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

public static class PosesConst
{
    public const string FullFace = "FullFace";
    public const string PistolFire = "PistolFire";
    public const string BladeStab = "BladeStab";
    public const string Buffing = "Buffing";
    public const string Evade = "Evade";
    public const string Suffering = "Suffering";
    public const string Buffed = "Buffed";
    public const string DeathDoor = "DeathDoor";
    public const string ClawStrike = "ClawStrike";
    public const string Call = "Call";
    public const string Scream = "Scream";
}

