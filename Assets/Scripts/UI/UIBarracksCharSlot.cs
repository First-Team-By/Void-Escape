using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class UIBarracksCharSlot : MonoBehaviour , IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _characterPrefab;

    [SerializeField] private Image _portrait;

    [SerializeField] private Text _characterClass;

    [SerializeField] private Text _characterFullName;

    public EntityCardScript EntityCard { get; set; }

    public CharacterInfo CharacterInfo { get; set; }

    public Text CharacterClass => _characterClass;

    public Text CharacterFullName => _characterFullName;

    public int CharacterId { get; set; }

    public Image Portrait => _portrait;

    public GameObject CharacterPrefab
    {
        get { return _characterPrefab; }
        set { _characterPrefab = value; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var entity = CharacterInfo.CharacterPrefab.GetComponent<EntityBase>();

        entity.Health = CharacterInfo.CurrentHealth;

        entity.FullName = CharacterInfo.FullName;

        EntityCard.FillInfo(entity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
