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
    public EntityPose ActorPose { get; set; }
    public EntityBase Actor { get; set; }
}

public class TargetState
{
    public float HealthChanged { get; set; }
    public EntityPose Pose { get; set; }
    public EntityBase Target { get; set; }
    public Sprite Effect { get; set; }
    public string ConditionName { get; set; }
}

public enum EntityPose
{
    AttackPose,
    SufferingPose,
    EvadePose,
    ReinforcedPose
}
