using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Battery : ResourceItem
{
	protected override string IconName => "ui_energybattery_sprite";
	
	public Battery()
	{
		Resources.Energy = 20;
	}
}
