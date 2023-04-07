using UnityEngine;

namespace Assets.Scripts.Entities.Serializable
{
    public static class EquipmentFactory
    {
        public static UIItem CreateItem(Equipment equipment, Transform parent)
        {
            var item = GameObject.Instantiate(Global.CommonPrefabs.ItemContainer, parent).GetComponent<UIItem>();

            item.Equipment = equipment;

            item.Image.sprite = equipment.Icon;

            return item;
        }
    }
}
