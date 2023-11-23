using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Officer : CharacterInfo
{
    public override List<CharacterCommand> NativeCommands {get;} = new List<CharacterCommand>()
    {
        new DoubleTap(),
        new SingleFire()
    };
    public override string SufferingPoseName => "";

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

        Conditions.AddMutilation(new Limping());

        //GetBleeded(0.1f, 100);

        AddPose("FirePistol", "Characters/Officer/officer_attackpose_sprite");
    }

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case PosesConst.PistolFire:
                return GetPoseInner("FirePistol");
        }

        return null;
    }
}