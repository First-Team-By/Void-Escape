using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MutantScout : Mutant
{
	public override string SufferingPoseName => "Enemies/Mutant/MutantScout/mutant-scout-suffering-pose_sprite";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Enemies/Mutant/MutantScout/mutant-scout-fullface_sprite";
	public override string EvadePoseName => "";

	public MutantScout()
	{
		EntityClass = EntityClass.MutantScout;
		AddPose("ClawStrike", "Enemies/Mutant/MutantScout/mutant-scout-clawstrike_sprite");
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

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case PosesConst.ClawStrike:
                return GetPoseInner("ClawStrike");
        }

        return null;
    }

}
