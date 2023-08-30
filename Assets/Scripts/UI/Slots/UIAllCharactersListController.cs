using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIAllCharactersListController : UIListController<CharacterInfo>
{
    public override List<CharacterInfo> Objects => Global.allCharacters.CharacterInfos;

    public override void BindObject(UIDragContainer container, CharacterInfo obj)
    {
        var objectContainer = container as UICharacterContainer;
        
        if (objectContainer == null)
        {
            Debug.LogError($"{typeof(UICharacterContainer)}: bind object invalid argument");
        }

        objectContainer.Character = obj;
        objectContainer.SetPanelImages(obj.FullFaceSprite, obj.FullFaceSprite);
    }
}
