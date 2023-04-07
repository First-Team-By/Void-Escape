using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : EnemyInfo
{
    public override string SufferingPoseName => "";

    public override string AttackPoseName => "";

    public override string PortraitName => "";

    public override string DeathDoorSpriteName => "";

    public override string FullFaceSpriteName => "enemy_placeholder";

    public override string EvadePoseName => "";

    public Mutant()
    {
        EntityClass = EntityClass.Mutant;
    }
}