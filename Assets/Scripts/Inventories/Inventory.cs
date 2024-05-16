using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    public List<ResourceItem> ResourceItems { get; set; }
    public List<Equipment> Equipments { get; set; }

    public List<StoragePosition> Items { get; set; }


    public Inventory()
    {
        Equipments = new List<Equipment>();
        ResourceItems = new List<ResourceItem>();
        Items = new List<StoragePosition>();
    }

    public StoragePosition AddItem(Item item)
    {
        var itemInInvetory = Items.Where(x => x.Item.GetType() == item.GetType()).FirstOrDefault();
        if (itemInInvetory != null)
        {
            itemInInvetory.Amount++;
            return itemInInvetory;
        }
        else
        {
            var newItem = new StoragePosition(item, this);
            Items.Add(newItem);
            return newItem;
        }
    }

    public void RemoveItem(Item item)
    {
        var itemInInvetory = Items.Where(x => x.Item.GetType() == item.GetType()).FirstOrDefault();
        if (itemInInvetory != null)
        {
            itemInInvetory.Amount--;
            if (itemInInvetory.Amount < 1)
                Items.Remove(itemInInvetory);
        }
    }

    public void AddItems(List<Item> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void RemoveItems(List<Item> items)
    {
        foreach(var item in items)
        {
            RemoveItem(item);
        }
    }


    private void AddResourceItem(ResourceItem resourceItem)
    {
        ResourceItems.Add(resourceItem);
    }

    private void AddEquipment(Equipment equipment)
    {
        Equipments.Add(equipment);
    }

    public void AddToInventory(LootItem lootItem)
    {
        var item = lootItem.GetItem();
        if (item is ResourceItem)
        {
            AddResourceItem(item as ResourceItem);
        }
        else
            if (item is Equipment)
        {
            AddEquipment(item as Equipment);
        }
    }

    public void AddToInventory(List<LootItem> loot)
    {
        foreach (var lootItem in loot)
        {
            AddToInventory(lootItem);
        }
    }

    public void Clear()
    {
        ResourceItems.Clear();
        Equipments.Clear();
    }
}
