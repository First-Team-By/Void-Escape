using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIMedicalIdleCharacterList : UIListController<CharacterInfo>
{
    public override List<CharacterInfo> Objects => Global.AllCharacters.CharacterInfos
                                                    .Where(x => x.MedicalState == MedicalState.Idle).ToList();

    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);
        
        container.SetPanelImages(obj.FullFaceSprite, obj.FullFaceSprite);
    }

    protected override void Init()
    {
        return;
    }
}
