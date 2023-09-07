using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntityCardScript : EntityCardBase
{
    protected EntityInfo _entity;

    [SerializeField] protected Image _image;
    [SerializeField] protected Image _currentHealth;
    [SerializeField] protected List<GameObject> _characterSkills;
    [SerializeField] protected TMP_Text _entityType;
    [SerializeField] protected TMP_Text _rarity;
    [SerializeField] protected TMP_Text _initiative;
    [SerializeField] protected TMP_Text _fullName;
    [SerializeField] protected TMP_Text _disabilities;
    [SerializeField] protected UIEquipmentSlot _weaponSlot;
    [SerializeField] protected UIEquipmentSlot _deviceSlot;
    [SerializeField] protected UIEquipmentSlot _armorSlot;
    [SerializeField] protected bool _interactable;

    public TMP_Text EntityClassCaption
    {
        get { return _entityType; }
        set { _entityType = value; }
    }

    public TMP_Text EntityClassRarity
    {
        get { return _rarity; }
        set { _rarity = value; }
    }

    protected override void Init()
    {

    }

    public override void FillAdditional(EntityInfo entity)
    {
        _entity = entity;

        gameObject.SetActive(true);

        _image.sprite = entity.FullFaceSprite;

        EntityClassCaption.text = entity.ClassName;

        _initiative.text = entity.EntityChars.Initiative.ToString();

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _fullName.text = entity.FullName;

        var character = entity as CharacterInfo;

        if (character != null)
        {
            EntityClassRarity.text = character.RarityToString;
        }

        RefreshCommands();
        RefreshDisabilities();
    }

    protected void RefreshDisabilities()
    {
        if (_disabilities != null)
            _disabilities.text = _entity.Conditions.GetDisabilities();
    }

    public void RefreshEquipments()
    {
        if (_weaponSlot.EquipmentContainer != null)
        {
            Destroy(_weaponSlot.EquipmentContainer.gameObject);
        }

        if (((CharacterInfo)_entity).Weapon != null)
        {
            CreateItem(((CharacterInfo)_entity).Weapon, _weaponSlot.gameObject.transform);
        }

        if (_deviceSlot.EquipmentContainer != null)
        {
            Destroy(_deviceSlot.EquipmentContainer.gameObject);
        }

        if (((CharacterInfo)_entity).Device != null)
        {
            CreateItem(((CharacterInfo)_entity).Device, _deviceSlot.gameObject.transform);
        }

        if (_armorSlot.EquipmentContainer != null)
        {
            Destroy(_armorSlot.EquipmentContainer.gameObject);
        }

        if (((CharacterInfo)_entity).Armor != null)
        {
            CreateItem(((CharacterInfo)_entity).Armor, _armorSlot.gameObject.transform);
        }
    }

    protected void RefreshCommands()
    {
        int i = 0;

        foreach (var slotCommand in _characterSkills)
        {
            var image = slotCommand.GetComponent<Image>();

            image.sprite = null;

            image.color = Color.white;
        }

        foreach (var command in ((CharacterInfo)_entity).NativeCommands)
        {
            var image = _characterSkills[i].GetComponent<Image>();

            image.sprite = command.Icon;

            _characterSkills[i].GetComponent<ToolTipAppear>().ToolTipString = command.FullDescription;

            i++;

            if (command.IsAvaliable(_entity))
            {
                image.color = Color.white;
            }
            else
            {
                image.color = Color.gray;
            }
        }
    }

    private void CreateItem(Equipment equipment, Transform transform)
    {
        var item = ItemFactory.CreateItem(equipment, transform);
        item.ParentTo(transform);

        item.GetComponent<CanvasGroup>().blocksRaycasts = _interactable;

        item.transform.localPosition = Vector3.zero;
    }


}
