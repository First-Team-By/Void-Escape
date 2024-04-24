using System.Linq;
using Random = UnityEngine.Random;

public class CallBeater : EntityCommand
{
    public override string IconName { get; }
    public override string EffectName => "effect_call_sprite";

    public CallBeater()
    {
        Name = "Призыв загонщика";
    }

    public override CommandResult Execute(BattleCommandExecuteInfo executeInfo)
    {
        var result = base.Execute(executeInfo);
        var availableTargets = executeInfo.Routine.EnemyPositions.Where(x => x.entityContainer == null).ToList();
        if (availableTargets.Any())
        {
            var index = Random.Range(0, availableTargets.Count);

            var target = availableTargets[index];

            var beater = new MutantBeater();

            executeInfo.Routine.SetEnemyAt(beater, target);

            result.ActorPoseName = PosesConst.Call;

            var targetState = new TargetState()
            {
                HealthChanged = 0f,
                Target = beater,
                PoseName = PosesConst.Scream,
                ConditionName = "Призыв",
                Effect = this.Effect
        };

            result.TargetStates.Add(target.Position, targetState);
        }


        return result;
    }
}
