using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class CommandResult
{
    public Dictionary<int, TargetState> TargetStates { get; set; } = new Dictionary<int, TargetState>();
    public EntityPose ActorPose { get; set; }
}

public class TargetState
{
    public float HealthChanged { get; set; }
    public EntityPose Pose { get; set; }
    public EntityConditions AddedConditions { get; set; } = new EntityConditions();
    public EntityConditions RemovedConditions { get; set; } = new EntityConditions();


}

public enum EntityPose
{
    AttackPose,
    SufferingPose,
    EvadePose,
    ReinforcedPose
}
