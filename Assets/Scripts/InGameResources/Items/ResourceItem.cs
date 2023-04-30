using UnityEngine;

public abstract class ResourceItem 
{
    public Resource Resources { get; private set; }

    public Sprite Icon { get; private set; }
    protected abstract string IconName { get; }

    public ResourceItem()
    {
        Icon = UnityEngine.Resources.Load<Sprite>("Sprites/Items/Resources/Energy/" + IconName);
    }
}

