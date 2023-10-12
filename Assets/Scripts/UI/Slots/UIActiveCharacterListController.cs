using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIActiveCharacterListController : UIListController<CharacterInfo>
{
    public override List<CharacterInfo> Objects => Global.allCharacters.CharacterInfos
                                                    .Where(x => x.MedicalState == MedicalState.Idle).ToList();

    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        container.SetPanelImages(obj.FullFaceSprite, obj.FullFaceSprite);
    }
}