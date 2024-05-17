using UnityEngine;

public abstract class ResourceItem : Item
{
    public Resource Resources { get; private set; }

    public ResourceItem(): base()
    {
        Resources = new Resource();
        
    }
    protected override void Init()
    {
        Icon = UnityEngine.Resources.Load<Sprite>("Sprites/Items/Resources/" + IconName);
    }
}

