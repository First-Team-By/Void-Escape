using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CombatEngineer : CharacterInfo
{
	public override List<CharacterCommand> NativeCommands { get; } = new List<CharacterCommand>()
	{
		new DefendingShot()
	};

	public override string SufferingPoseName => "";

	public override string AttackPoseName => "Characters/Engineer/engineer-attackpose_sprite";

	public override string PortraitName => "Characters/Engineer/engineer-portrait_sprite";

	public override string DeathDoorSpriteName => "";

	public override string FullFaceSpriteName => "Characters/Engineer/enginner-fullface_sprite";

	public override string EvadePoseName => "";
	
	public CombatEngineer()
	{
		Weapon = new Pistol();

		Armor = new BodyArmorLigth();

		EntityClass = EntityClass.Engineer;

		Rarity = Rarity.Common;
	}

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case Poses.PistolFire:
                return AttackPose;
        }

        return null;
    }
}
