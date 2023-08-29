using UnityEngine;

public static class ItemFactory
{
    public static UIItem CreateItem(Equipment equipment, Transform parent)
    {
        var item = GameObject.Instantiate(Global.CommonPrefabs.ItemContainer, parent).GetComponent<UIItem>();

        item.Equipment = equipment;

        item.Icon.sprite = equipment.Icon;

        return item;
    }
}
