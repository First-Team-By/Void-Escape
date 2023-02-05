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

    [SerializeField] private Text _characterName;

    public EntityCardScript EntityCard { get; set; }

    public CharacterInfo CharacterInfo { get; set; }

    public Text CharacterName => _characterName;

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

        EntityCard.FillInfo(entity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
