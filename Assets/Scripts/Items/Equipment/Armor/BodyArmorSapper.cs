using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BodyArmorSapper : EntityArmor
{
    public BodyArmorSapper() : base() 
    {
        Type = ArmorType.Sapper;

        SlotType = SlotType.Armor;

        _resistances.BurnResistance = 20;

        _resistances.PoisonResistance = 5;
    }

    public override string IconName => "BodyArmorSapper";
}

