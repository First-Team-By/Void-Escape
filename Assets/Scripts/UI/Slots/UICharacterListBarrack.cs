using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterListBarrack : UIAllCharactersListController
{
    [SerializeField] private EntityCardInventoryInteract _card;
    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        if (container is UICharacterContainer characterContainer)
        {
            characterContainer.ContainerClicked += OnContainerClick;
        }
    }

    private void OnContainerClick(UIContainer container)
    {
        var characterContainer = container as UICharacterContainer;

        _card.FillInfo(characterContainer.Character);
    }
}
