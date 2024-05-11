﻿using System.Collections.Generic;
using UnityEngine;


public class Medic : CharacterInfo
{
    public override string SufferingPoseName => "Characters/Medic/medic_fullface_sprite";

    public override string PortraitName => "Characters/Medic/medic_portrait_sprite";

    public override string DeathDoorSpriteName => "";

    public override string FullFaceSpriteName => "Characters/Medic/medic_fullface_sprite";

    public override string EvadePoseName => "";



    public override List<CharacterCommand> NativeCommands => new List<CharacterCommand>()
    {
        new HealOne(),
        new Coagulator(),
        new DeepCut()
    };

    

    public Medic() : base()
    {
        Weapon = new Scalpel();

        Device = new FirstAidKit();

        Armor = new BodyArmorLigth();

        EntityClass = EntityClass.Medic;

        AddPose("ScalpelSlash", "Characters/Medic/medic_attackpose_sprite");


        //Conditions.brokenArm = 1;

        Conditions.brokenLeg = 1;
        Health = Health / 2;
    }

    public override Sprite GetCustomPose(string pose)
    {
        switch (pose)
        {
            case PosesConst.BladeSlash:
                return GetPoseInner("ScalpelSlash");
        }

        return null;
    }

}
