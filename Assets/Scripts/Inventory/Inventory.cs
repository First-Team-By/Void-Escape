using System;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

public class Inventory
{
    public Resource Resources { get; set; }
    public List<Equipment> Equipments { get; set; }

    public void AddResource(Resource resource)
    {
        Resources.Energy += resource.Energy;
        Resources.Medicine += resource.Medicine;
        Resources.Metal += resource.Metal;
        Resources.Electronics += resource.Electronics;
    }

    internal void AddEquipment(Equipment equipment)
    {
        Equipments.Add(equipment);
    }
}
