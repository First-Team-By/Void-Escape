using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantScout : Mutant
{
	public override string SufferingPoseName => "Enemies/Mutant/MutantScout/mutant-scout-suffering-pose_sprite";

	public override string AttackPoseName => "";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Enemies/Mutant/MutantScout/mutant-scout-fullface_sprite";
	public override string EvadePoseName => "";

	public MutantScout()
	{
		EntityClass = EntityClass.MutantScout;
	}

}
