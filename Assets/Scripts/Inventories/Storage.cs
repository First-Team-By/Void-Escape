using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Storage : Inventory
{
    public Resource Resources { get; private set; }

    public Storage() : base()
    {
        Equipments = new List<Equipment>() { new BodyArmorLigth(), new BodyArmorSapper(), new BodyArmorHidden(), new Pistol(), new Scalpel(), new Blade(),
            new FirstAidKit()  };
        Resources = new Resource() { Electronics = 20 };
    }

    private void ConvertToResources(List<ResourceItem> resourceItems)
    {
        foreach (var item in resourceItems)
        {
            Resources += item.Resources;
        }
    }

    public void TransferFromInventory()
    {
        Equipments.AddRange(Global.inventory.Equipments);
        ConvertToResources(Global.inventory.ResourceItems);
        Global.inventory.Clear();
    }
}
