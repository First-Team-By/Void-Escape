using System.Linq;
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

    private void SelectCaracter(CharacterInfo character)
    {
        _card.FillInfo(character);
        _card.RefreshEquipments();
    }

    private void OnContainerClick(UIContainer container)
    {
        SelectCaracter((container as UICharacterContainer).Character);
    }
    protected override void Init()
    {
        var character = Objects.FirstOrDefault();
        if (character != null) 
        {
            SelectCaracter(character);
        }
    }
}
