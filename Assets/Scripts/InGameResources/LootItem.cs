using System;


public class LootItem
{
    public Type Type { get; set; }
    public int Amount { get; set; }

    public object GetItem()
    {
        return Activator.CreateInstance(Type);
    }

    public void AddToInventory(Inventory inventory)
    {
        var item = GetItem();
        if (item is ResourceItem)
        {
            inventory.AddResource((item as ResourceItem).Resources);
        }
        else
            if(item is Equipment)
        {
            inventory.AddEquipment(item as Equipment);
        }
    }

    public LootItem(Type type, int amount = 1)
    {
        Type = type; 
        Amount = amount;
    }

}
