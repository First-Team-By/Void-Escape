using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantBoss : Mutant
{
	public override string SufferingPoseName => "Enemies/Mutant/mutant_sufferingpose_sprite";

	public override string AttackPoseName => "";

	public override string PortraitName => "";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Enemies/Mutant/mutant-boss-fullface_sprite";

	public override string EvadePoseName => "";

	public MutantBoss()
	{
		EntityClass = EntityClass.Mutantboss;
	}
}
