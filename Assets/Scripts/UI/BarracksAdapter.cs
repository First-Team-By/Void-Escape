using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksAdapter : MonoBehaviour
{
    [SerializeField] private GameObject _barracksCharSlotPref;

    [SerializeField] private RectTransform _content;

    [SerializeField] private EntityCardScript _entityCard;

    private void OnEnable()
    {
        foreach (Transform item in _content.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var characterInfo in Global.allCharacters.CharacterInfos)
        {
            var barracksCharSlot = GameObject.Instantiate(_barracksCharSlotPref.gameObject) as GameObject;

            var uiBarracksCharSlot = barracksCharSlot.GetComponent<UIBarracksCharSlot>();

            uiBarracksCharSlot.Portrait.sprite = characterInfo.CharacterPrefab.GetComponent<SpriteRenderer>().sprite;

            uiBarracksCharSlot.CharacterPrefab = characterInfo.CharacterPrefab;

            uiBarracksCharSlot.CharacterId = characterInfo.Id;

            barracksCharSlot.transform.SetParent(_content, false);

            var character = characterInfo.CharacterPrefab.GetComponent<EntityBase>();

            uiBarracksCharSlot.CharacterClass.text = EntityBase.GetClassName(character.EntityClass);

            uiBarracksCharSlot.CharacterFullName.text = characterInfo.FullName;

            uiBarracksCharSlot.CharacterInfo = characterInfo;

            uiBarracksCharSlot.EntityCard = _entityCard;
        }
        if (_content.childCount > 0)
        {
            _content.GetChild(0).GetComponent<UIBarracksCharSlot>().DoSelect();
        }
        
    }
}
