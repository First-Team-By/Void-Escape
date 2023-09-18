using System;


public class LootItem
{
    public Type Type { get; set; }
    public int Amount { get; set; }

    public object GetItem()
    {
        return Activator.CreateInstance(Type);
    }

    public LootItem(Type type, int amount = 1)
    {
        Type = type; 
        Amount = amount;
    }
}
