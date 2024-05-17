using System.Collections.Generic;

public class UIInventoryItemListController : UIStorgePositionListController
{
    public override List<StoragePosition> Objects => Global.inventory.Items;

    //protected override GameObject _itemContainerPrefab => throw new System.NotImplementedException();

    protected override Inventory _parentInventory => Global.inventory;
}
