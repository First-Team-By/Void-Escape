using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIStorageItemListController : UIStorgePositionListController
{
    public override List<StoragePosition> Objects => Global.Storage.Items.Where(x => x.Item is Equipment).ToList();

   // protected override GameObject _itemContainerPrefab => Global.CommonPrefabs.ItemContainer;

    protected override Inventory _parentInventory => Global.Storage;
}
