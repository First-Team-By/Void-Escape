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
    }

    public override string IconName => "coagulatorcommand_sprite";
}
