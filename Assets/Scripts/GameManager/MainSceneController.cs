using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    void Start()
    {
        foreach (var character in Global.currentGroup.CurrentCharacterInfos)
        {
            var currentCharacter = Global.allCharacters.CharacterInfos.FirstOrDefault(x => x.Id == character.Id);

            currentCharacter = character;
            currentCharacter.Conditions.DropTemporaryConditions();
        }

        Global.currentGroup.CurrentCharacterInfos.Clear();
    }

    void Update()
    {
        
    }

    private void LoadAfterBattle()
    {

    }
}
