using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scalpel : EntityWeapon
{
    public Scalpel()
    {
        Type = WeaponType.Scalpel;

        SlotType = SlotType.Weapon;
    }

    protected override string IconName => "equipment_scalpel_sprite";
}
