using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemListController : UIListController<Equipment>
{
    public override List<Equipment> Objects => Global.storage.Equipments;

    public override void BindObject(UIDragContainer container, Equipment obj)
    {
        var objectContainer = container as UIEquipmentContainer;

        if (objectContainer == null)
        {
            Debug.LogError($"{typeof(UIEquipmentContainer)}: bind object invalid argument");
        }

        objectContainer.Equipment = obj;
        objectContainer.SetPanelImages(obj.Icon, obj.Icon);
    }
}
