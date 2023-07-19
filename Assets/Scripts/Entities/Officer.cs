using System.Collections.Generic;
using UnityEngine;

public class Officer : CharacterInfo
{
    public override List<CharacterCommand> NativeCommands => new List<CharacterCommand>()
    {
        new DoubleTap(),
        new SingleFire()
    };
    public override string SufferingPoseName => "";

    public override string AttackPoseName => "Characters/Officer/officer_attackpose_sprite";

    public override string PortraitName => "Characters/Officer/officer_portrait_sprite";

    public override string DeathDoorSpriteName => "";

    public override string FullFaceSpriteName => "Characters/Officer/officer_fullface_sprite";

    public override string EvadePoseName => "";

    public Officer() : base()
    {
        Weapon = new Pistol();

        Armor = new BodyArmorLigth();

        EntityClass = EntityClass.Officer;

        Rarity = Rarity.Rare;

        //GetBleeded(0.1f, 100);
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