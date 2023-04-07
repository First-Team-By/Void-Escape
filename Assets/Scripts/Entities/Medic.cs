using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Medic : CharacterInfo
{
    public override string SufferingPoseName => "";

    public override string AttackPoseName => "";

    public override string PortraitName => "medicportrait_sprite";

    public override string DeathDoorSpriteName => "";

    public override string FullFaceSpriteName => "medic_sprite";

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

        EntityClass = EntityClass.Medic;
    }

    
}
