using UnityEngine;

public static class ItemFactory
{
    public static UIEquipmentContainer CreateItem(Equipment equipment, Transform parent)
    {
        var container = GameObject.Instantiate(Global.CommonPrefabs.ItemContainer, parent).GetComponent<UIEquipmentContainer>();

        container.SetBusinessObject(equipment);
        container.SetPanelImages(equipment.Icon, equipment.Icon);

        return container;
    }
}
