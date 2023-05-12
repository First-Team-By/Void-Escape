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
        Resources = new Resource() { Electronics = 20 };
    }

    private void ConvertToResources()
    {
        foreach (var item in ResourceItems)
        {
            Resources += item.Resources;
        }
    }

    public void TransferFromInventory()
    {
        ResourceItems = Global.inventory.ResourceItems;
        Equipments = Global.inventory.Equipments;
        Global.inventory.Clear();
        ConvertToResources();
    }
}
