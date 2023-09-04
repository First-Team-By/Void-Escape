using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemListController : UIListController<Equipment>
{
    public override List<Equipment> Objects => Global.storage.Equipments;

    public override void BindObject(UIContainer container, Equipment obj)
    {
        base.BindObject(container, obj);
        
        container.SetPanelImages(obj.Icon, obj.Icon);
    }
}
