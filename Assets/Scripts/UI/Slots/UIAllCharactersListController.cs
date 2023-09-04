using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIAllCharactersListController : UIListController<CharacterInfo>
{
    public override List<CharacterInfo> Objects => Global.allCharacters.CharacterInfos;

    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        container.SetPanelImages(obj.FullFaceSprite, obj.FullFaceSprite);
    }
}
