using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Battery : ResourceItem
{
    public Battery()
    {
        Resources.Energy = 20;
    }

    protected override string IconName => "ui_energybattery_sprite";
}
