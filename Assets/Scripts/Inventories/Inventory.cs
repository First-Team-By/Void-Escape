using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    public List<ResourceItem> ResourceItems 
    {
        get 
        {
            return Items.Where(x => x.Item is ResourceItem).Select(x => x.Item as ResourceItem).ToList();
        }
    }
   // public List<Equipment> Equipments { get; set; }

    public List<StoragePosition> Items { get; set; }


    public Inventory()
    {
       // Equipments = new List<Equipment>();
        //ResourceItems = new List<ResourceItem>();
        Items = new List<StoragePosition>();
    }

    public StoragePosition AddItem(Item item, int num = 1)
    {
        var itemInInvetory = Items.Where(x => x.Item.GetType() == item.GetType()).FirstOrDefault();
        if (itemInInvetory != null)
        {
            itemInInvetory.Amount += num;
            return itemInInvetory;
        }
        else
        {
            var newItem = new StoragePosition(item, this);
            Items.Add(newItem);
            return newItem;
        }
    }

    public void RemoveItem(Item item, int num = 1)
    {
        var itemInInvetory = Items.Where(x => x.Item.GetType() == item.GetType()).FirstOrDefault();
        if (itemInInvetory != null)
        {
            itemInInvetory.Amount -= num;
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

    public void AddItems(List<StoragePosition> positions)
    {
        foreach (var pos in positions)
        {
            AddItem(pos.Item, pos.Amount);
        }
    }

    public void RemoveItems(List<Item> items)
    {
        foreach(var item in items)
        {
            RemoveItem(item);
        }
    }


    //private void AddResourceItem(ResourceItem resourceItem)
    //{
    //    ResourceItems.Add(resourceItem);
    //}

    //private void AddEquipment(Equipment equipment)
    //{
    //    Equipments.Add(equipment);
    //}

    public void AddToInventory(LootItem lootItem)
    {
        var item = lootItem.GetItem();
        AddItem(item as Item);
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
        //ResourceItems.Clear();
        //Equipments.Clear();
        Items.Clear();
    }
}
