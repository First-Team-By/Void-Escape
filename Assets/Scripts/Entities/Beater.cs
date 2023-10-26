using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beater : Mutant
{
	public override string SufferingPoseName => "";

	public override string AttackPoseName => "";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Enemies/Mutant/Beater/mutant-beater-fullface_sprite";
	public override string EvadePoseName => "";
	
	public Beater()
	{
		EntityClass = EntityClass.MutantBeater;
	}
}
