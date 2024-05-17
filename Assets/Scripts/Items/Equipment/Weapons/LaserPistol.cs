using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPistol : Pistol
{
	protected override string IconName => "equipment-laserpistol_sprite";

    public LaserPistol(): base()
    {
        IsInfinite = false;
    }
}
