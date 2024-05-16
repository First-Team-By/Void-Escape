using System.Linq;
using UnityEngine;

public class UICharacterListBarrack : UIAllCharactersListController
{
    [SerializeField] private EntityCardInventoryInteract _card;

    private UICharacterContainer CurrentCharacter;
    public override void BindObject(UIContainer container, CharacterInfo obj)
    {
        base.BindObject(container, obj);

        if (container is UICharacterContainer characterContainer)
        {
            characterContainer.ContainerClicked += OnContainerClick;
            characterContainer.Character.EquipmentChanged += () => CurrentCharacter.RefreshEquipment();
        }
    }

    private void SelectCaracter(CharacterInfo character)
    {
        _card.FillInfo(character);
        _card.RefreshEquipments();
    }

    private void OnContainerClick(UIContainer container)
    {
        CurrentCharacter = container as UICharacterContainer;
        SelectCaracter(CurrentCharacter.Character);

    }
    protected override void Init()
    {
        var character = Objects.FirstOrDefault();
        if (character != null) 
        {
            SelectCaracter(character);
            var firstContainer = gameObject.GetComponentInChildren<UICharacterContainer>();
            if (firstContainer != null)
                CurrentCharacter = firstContainer;
        }
    }
}
