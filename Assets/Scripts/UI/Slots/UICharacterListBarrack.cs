using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterListBarrack : UIAllCharactersListController
{
    [SerializeField] private EntityCardInventoryInteract _card;
    public override void BindObject(UIDragContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        var characterContainer = container as UICharacterContainer;

        if (characterContainer != null)
        {
            characterContainer.CharacterClicked += _card.FillInfo;
        }
    }
}
