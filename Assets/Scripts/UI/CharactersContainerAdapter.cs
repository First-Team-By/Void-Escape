using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersContainerAdapter : MonoBehaviour
{
    [SerializeField] private GameObject _characterSlotPrefab;

    [SerializeField] private RectTransform _content;

    



    private void Start()
    {
        foreach (var characterInfo in Global.allCharacters.CharacterInfos)
        {
            var characterSlot = GameObject.Instantiate(_characterSlotPrefab.gameObject) as GameObject;
            var uiCharacterSlot = characterSlot.GetComponent<UICharacterSlot>();

            uiCharacterSlot.Portrait.sprite = characterInfo.CharacterPrefab.GetComponent<SpriteRenderer>().sprite;

            uiCharacterSlot.CharacterPrefab = characterInfo.CharacterPrefab;

            uiCharacterSlot.CharacterId = characterInfo.Id;
            characterSlot.transform.SetParent(_content, false);

            var character = characterInfo.CharacterPrefab.GetComponent<EntityBase>();


            uiCharacterSlot.CharacterName.text = EntityBase.GetClassName(character.EntityClass);
        }
    }
}
