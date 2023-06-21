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
            uiCharacterSlot.CharacterInfo = characterInfo;

            uiCharacterSlot.Portrait.sprite = characterInfo.FullFaceSprite;

            uiCharacterSlot.CharacterId = characterInfo.Id;
            characterSlot.transform.SetParent(_content, false);

            uiCharacterSlot.CharacterName.text = EnemyInfo.GetClassName(characterInfo.EntityClass);
        }
    }
}
