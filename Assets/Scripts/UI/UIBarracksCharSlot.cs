using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class UIBarracksCharSlot : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private Image _portrait;

    [SerializeField] private Text _characterClass;

    [SerializeField] private Text _characterFullName;

    public EntityCardScript EntityCard { get; set; }

    public CharacterInfo CharacterInfo { get; set; }

    public Text CharacterClass => _characterClass;

    public Text CharacterFullName => _characterFullName;

    public int CharacterId { get; set; }

    public Image Portrait => _portrait;

    public void OnPointerClick(PointerEventData eventData)
    {
        DoSelect();
    }

    public void DoSelect()
    {
        
        EntityCard.FillInfo(CharacterInfo);


    }
}
