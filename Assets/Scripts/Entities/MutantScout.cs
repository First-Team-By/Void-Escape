using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MutantScout : Mutant
{
	public override string SufferingPoseName => "Enemies/Mutant/MutantScout/mutant-scout-suffering-pose_sprite";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "Enemies/Mutant/MutantScout/mutant-scout-dead-pose_sprite";

	public override string FullFaceSpriteName => "Enemies/Mutant/MutantScout/mutant-scout-fullface_sprite";
	public override string EvadePoseName => "Enemies/Mutant/MutantScout/mutant-scout-evade-pose_sprite";

    private bool AlreadyCallBeater = false;

	public MutantScout()
	{
		EntityClass = EntityClass.MutantScout;
		AddPose("ClawStrike", "Enemies/Mutant/MutantScout/mutant-scout-clawstrike_sprite");
        AddPose("CallBeater", "Enemies/Mutant/MutantScout/mutant-scout-call-pose_sprite");
        Actions.Add(TryCallBeater);
        Actions.Add(TryClawStrike);
    }

	private bool TryClawStrike(BattleCommandExecuteInfo executeInfo, List<CharacterInfo> possibleTargets, out CommandResult result)
	{
        var clawStrike = new ClawStrike();
        result = null;

		var availableTargets = clawStrike.GetAvaliableTargets(Position, possibleTargets.Select(x => x as EntityInfo).ToList());
        if (availableTargets.Any())
		{
			var index = Random.Range(0, availableTargets.Count);
            var target = availableTargets[index];
			executeInfo.Targets.Add(target);
            result = clawStrike.Execute(executeInfo);
		}
		return result != null;
	}

    private bool TryCallBeater(BattleCommandExecuteInfo executeInfo, List<CharacterInfo> possibleTargets, out CommandResult result)
    {
        result = null;

        if (!AlreadyCallBeater && Random.Range(0, 100) <= 25)
        {
            var callBeater = new CallBeater();
            result = callBeater.Execute(executeInfo);
            AlreadyCallBeater = true;
        }

        return result != null && result.TargetStates.Count > 0;
    }

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case PosesConst.ClawStrike:
                return GetPoseInner("ClawStrike");
            case PosesConst.Call:
                return GetPoseInner("CallBeater");
        }

        return null;
    }

}
