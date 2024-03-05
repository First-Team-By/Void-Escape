using System.Linq;
using Random = UnityEngine.Random;

public class CallBeater : EntityCommand
{
    public override string IconName { get; }
    public override string EffectName { get; }

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
                Target = beater,
                PoseName = PosesConst.Scream,
                ConditionName = "Призыв"
            };

            result.TargetStates.Add(target.Position, targetState);
        }


        return result;
    }
}
