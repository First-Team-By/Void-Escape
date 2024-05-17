using UnityEngine;


public abstract class Equipment : Item
{
    protected override void Init()
    {
        Icon = Resources.Load<Sprite>("Sprites/Items/Equipment/" + IconName);
    }
}
