using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JosephSteels : Officer
{
	public override string SufferingPoseName => "Characters/JosephSteels/joseph-steels-suffering_sprite";

	public override string PortraitName => "Characters/JosephSteels/joseph-steels-portrait_sprite";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Characters/JosephSteels/joseph-steels-fullface_sprite";

	public override string EvadePoseName => "";
	
	public JosephSteels() : base()
	{
		EntityClass = EntityClass.JosephSteels;
		FullName = "Джозеф Стилс";

		AddPose("FirePistol", "Characters/JosephSteels/joseph-steels-firepistol_sprite");
        AddPose("BladeSlash", "Characters/JosephSteels/joseph-steels-bladeslash_sprite");

    }
}
	
