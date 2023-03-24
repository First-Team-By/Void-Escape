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

    private void OnEnable()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DoSelect();
    }

    public void DoSelect()
    {
        var character = CharacterInfo.CharacterPrefab.GetComponent<EntityBase>() as Character;

        character.Health = CharacterInfo.CurrentHealth;

        character.FullName = CharacterInfo.FullName;

        character.Weapon = CharacterInfo.Weapon;

        character.Tool = CharacterInfo.Tool;

        EntityCard.FillInfo(character);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
