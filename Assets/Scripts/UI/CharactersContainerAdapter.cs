using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersContainerAdapter : MonoBehaviour
{
    [SerializeField] private GameObject _characterSlotPrefab;

    [SerializeField] private RectTransform _content;

    [SerializeField] private Text _countCharacterSlots;



    private void Start()
    {
        foreach (var characterInfo in Global.allCharacters.CharacterInfos)
        {
            var characterSlot = GameObject.Instantiate(_characterSlotPrefab.gameObject) as GameObject;

            characterSlot.GetComponent<UICharacterSlot>().Portrait.sprite = characterInfo.CharacterPrefab.GetComponent<SpriteRenderer>().sprite;

            characterSlot.GetComponent<UICharacterSlot>().CharacterPrefab = characterInfo.CharacterPrefab;

            characterSlot.transform.SetParent(_content, false);
        }
    }
}
