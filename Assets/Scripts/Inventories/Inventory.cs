using System;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory
{
    public List<ResourceItem> ResourceItems { get; set; }
    public List<Equipment> Equipments { get; set; }


    public Inventory()
    {
        Equipments = new List<Equipment>();
        ResourceItems = new List<ResourceItem>();
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
