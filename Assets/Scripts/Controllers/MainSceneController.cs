using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private InventoryPanel inventoryPanel;

    void Start()
    {
        foreach (var character in Global.currentGroup.CurrentCharacterInfos)
        {
            var currentCharacter = Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == character.Id);

            currentCharacter = character;
            currentCharacter.Conditions.DropTemporaryConditions();
        }

        Global.currentGroup.CurrentCharacterInfos.Clear();

        Global.storage.TransferFromInventory();

        inventoryPanel.Inventory = Global.storage;
    }

    void Update()
    {

    }

    private void LoadAfterBattle()
    {

    }
}
