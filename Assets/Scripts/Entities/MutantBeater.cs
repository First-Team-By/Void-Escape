using System.Collections;
using System.Collections.Generic;
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
        AddPose("FearingScream", "Enemies/Mutant/Beater/mutant-beater-scream_sprite");
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
