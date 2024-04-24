using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MutantBeater : Mutant
{
	public override string SufferingPoseName => "";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Enemies/Mutant/Beater/mutant-beater-fullface_sprite";
	public override string EvadePoseName => "";
	
	public MutantBeater()
	{
		EntityClass = EntityClass.MutantBeater;
        AddPose("ClawStrike", "Enemies/Mutant/Beater/mutant-beater-clawstrike_sprite");
        AddPose("FearingScream", "Enemies/Mutant/Beater/mutant-beater-scream_sprite");
        Actions.Add(TryClawStrike);
        Actions.Add(TryFearingHowl);
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

    private bool TryFearingHowl(BattleCommandExecuteInfo executeInfo, List<CharacterInfo> possibleTargets, out CommandResult result)
    {
        var fearingHowl = new FearingHowl();
        result = null;
        var availableTargets = fearingHowl.GetAvaliableTargets(Position, possibleTargets.Select(x => x as EntityInfo).ToList());
        if (availableTargets.Any())
        {
            executeInfo.Targets = availableTargets;
            result = fearingHowl.Execute(executeInfo);
        }
        return result != null;
    }

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case PosesConst.ClawStrike:
                return GetPoseInner("ClawStrike");
            case PosesConst.Scream:
                return GetPoseInner("FearingScream");
        }

        return null;
    }
}
