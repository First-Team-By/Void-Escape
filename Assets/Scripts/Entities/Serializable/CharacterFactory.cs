using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public static class CharacterFactory
{
    public static CharacterInfo CreateCharacterInfo(GameObject prefab)
    {
        var characterInfo = new CharacterInfo();

        characterInfo.CharacterPrefab = prefab;

        return characterInfo;

    }

    public static CurrentCharacterInfo CreateCurrentCharacterInfo(Character character)
    {
        var currentCharacterInfo = new CurrentCharacterInfo();
        currentCharacterInfo.CharacterPrefab = character.Prefab;
        currentCharacterInfo.CurrentHealth = character.Health;
        currentCharacterInfo.CurrentConditions = character.Conditions;
        currentCharacterInfo.Position = character.Position;
        return currentCharacterInfo;

    }
}

