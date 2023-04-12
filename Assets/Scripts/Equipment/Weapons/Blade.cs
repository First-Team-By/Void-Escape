using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Blade : EntityWeapon
{
    public Blade()
    {
        Type = WeaponType.Blade;

        SlotType = SlotType.Weapon;
    }

    public override string IconName => "equipment_blade_sprite"; 
}

