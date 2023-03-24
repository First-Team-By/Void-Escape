using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

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
