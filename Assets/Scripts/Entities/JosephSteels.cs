using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JosephSteels : Officer
{
	public override string SufferingPoseName => "";

	public override string AttackPoseName => "Characters/JosephSteels/joseph-steels-attackpose_sprite";

	public override string PortraitName => "Characters/JosephSteels/joseph-steels-portrait_sprite";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Characters/JosephSteels/joseph-steels-fullface_sprite";

	public override string EvadePoseName => "";
	
	public JosephSteels() : base()
	{
		EntityClass = EntityClass.JosephSteels;
		FullName = "Джозеф Стилс";
	}
}
	
