using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BodyArmorHidden : EntityArmor
{
    public BodyArmorHidden() : base() 
    {
        Type = ArmorType.Hidden;

        SlotType = SlotType.Armor;

        _resistances.DamageResistance = 5;
        _resistances.BleedResistance = 5;
        _resistances.BurnResistance = 5;
        _resistances.PoisonResistance = 5;
    }

    public override string IconName => "BodyArmorHidden";
}

