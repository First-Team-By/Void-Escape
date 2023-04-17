using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

public class BodyArmorLigth : EntityArmor
{
    public BodyArmorLigth() : base()
    {
        Type = ArmorType.Light;

        SlotType = SlotType.Armor;

        _resistances.BleedResistance = 10;

        _resistances.DamageResistance = 5;
    }

    public override string IconName => "BodyArmorLigth_1.1";

}

