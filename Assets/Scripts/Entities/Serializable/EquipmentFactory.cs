using UnityEngine;

public static class ItemFactory
{
    public static UIDragItemContainer CreateItem(Item item, Transform parent)
    {
        var container = GameObject.Instantiate(Global.CommonPrefabs.ItemContainer, parent).GetComponent<UIDragItemContainer>();

        container.SetBusinessObject(item);
        container.SetPanelImages(item.Icon, item.Icon);

        return container;
    }
}
