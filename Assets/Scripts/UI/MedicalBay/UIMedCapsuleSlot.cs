using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMedCapsuleSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject _cplPanel;
    [SerializeField] private Button _healthButton;
    [SerializeField] private Button _traumaButton;
    [SerializeField] private Button _mutilationButton;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var dragChar = eventData.pointerDrag;
            var character = dragChar.GetComponent<UICharacterSlot>();
            if (character != null)
            {
                var characterInfo = character.CharacterInfo;
                _healthButton.gameObject.SetActive(characterInfo.Health < characterInfo.EntityChars.MaxHealth);
                _traumaButton.gameObject.SetActive(characterInfo.Conditions.HasTrauma);
                _mutilationButton.gameObject.SetActive(characterInfo.Conditions.Mutilations.Count > 0);
            }

            dragChar.transform.SetParent(gameObject.transform);

            dragChar.GetComponent<RectTransform>().localPosition = Vector2.zero;

            _cplPanel.SetActive(true);
        }
    }
}
