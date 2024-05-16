using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment : Item
{
    protected override void Init()
    {
        Icon = Resources.Load<Sprite>("Sprites/Items/Equipment/" + IconName);
    }
}
