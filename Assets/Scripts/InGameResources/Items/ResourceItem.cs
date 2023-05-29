using UnityEngine;

public abstract class ResourceItem : IItem 
{
    public Resource Resources { get; private set; }

    public Sprite Icon { get; private set; }
    protected abstract string IconName { get; }

    public ResourceItem()
    {
        Resources = new Resource();
        Icon = UnityEngine.Resources.Load<Sprite>("Sprites/Items/Resources/Energy/" + IconName);
    }
}

