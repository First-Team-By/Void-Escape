using System;
using System.Collections.Generic;

[Obsolete]
public class UIItemListController : UIListController<Equipment>
{
    public override List<Equipment> Objects => Global.Storage.Equipments;

    public override void BindObject(UIContainer container, Equipment obj)
    {
        base.BindObject(container, obj);
        
        container.SetPanelImages(obj.Icon, obj.Icon);
    }

    protected override void Init()
    {
        return;
    }
}
