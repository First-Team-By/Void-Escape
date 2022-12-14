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
    public static CharacterInfo CreateCharacterInfo(GameObject prefab, int id)
    {
        var characterInfo = new CharacterInfo();

        characterInfo.CharacterPrefab = prefab;
        characterInfo.Id = id;
        characterInfo.CurrentHealth = prefab.GetComponent<Character>().EntityChars.MaxHealth;

        return characterInfo;

    }

    public static CharacterInfo CreateCharacterInfo(Character character)
    {
        var characterInfo = new CharacterInfo();

        characterInfo.CharacterPrefab = character.Prefab;
        var id = 0;
        if (Global.allCharacters.CharacterInfos.Count > 0)
        {
           id = Global.allCharacters.CharacterInfos.Select(x => x.Id).Max() + 1;
        }
        characterInfo.Id = id;
        characterInfo.CurrentHealth = character.Prefab.GetComponent<Character>().EntityChars.MaxHealth;

        return characterInfo;
    }

    public static CurrentCharacterInfo CreateCurrentCharacterInfo(CharacterInfo characterInfo, int position)
    {
        var currentCharacterInfo = new CurrentCharacterInfo();
        currentCharacterInfo.CharacterPrefab = characterInfo.CharacterPrefab;
        currentCharacterInfo.CurrentHealth = characterInfo.CurrentHealth;
        currentCharacterInfo.Conditions = characterInfo.Conditions;
        currentCharacterInfo.Position = position;
        return currentCharacterInfo;
    }
}

