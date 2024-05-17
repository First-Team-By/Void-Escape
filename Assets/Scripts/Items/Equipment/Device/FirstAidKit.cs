using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstAidKit : EntityDevice
{
    public FirstAidKit()
    {
        Type = DeviceType.FirstAidKit;

        SlotType = SlotType.Device;
    }

    protected override string IconName => "equipment_firstaidkit_sprite";

}
