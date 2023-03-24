using Assets.Scripts.Entities.Serializable;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityCardScript : EntityCardBase
{
    [SerializeField] private Image _image;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private List<GameObject> _characterSkills; 

    [SerializeField] private TMP_Text _entityType;

    [SerializeField] private TMP_Text _initiative;

    [SerializeField] private TMP_Text _fullName;

    [SerializeField] private EquipmentSlot _weaponSlot;

    private EntityBase _entity;

    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private InventoryPanel _inventorySlot; 

    public TMP_Text EntityType
    { 
        get { return _entityType; } 
        set { _entityType = value; } 
    }

    private void Start()
    {
        _weaponSlot.OnEquipped += Equip;

        if (_inventoryPanel != null )
        {
            _inventorySlot.OnUnEquip += UnEquip;
        }
    }

    private void UnEquip(Equipment equipment)
    {
        if (equipment is EntityWeapon)
        {
            ((Character)_entity).Weapon = null;//оружие по умолчанию
        }

        Global.inventory.Add(equipment);

        RefreshCommands();
    }

    private void Equip(Equipment equipment)
    {
        if (equipment is EntityWeapon)
        {
            ((Character)_entity).Weapon = equipment as EntityWeapon;
        }

        Global.inventory.Remove(equipment);

        RefreshCommands();
    }

    public override void FillAdditional(EntityBase entity)
    {
        _entity = entity;

        gameObject.SetActive(true);

        _image.sprite = entity.ProfileSprite;

        EntityType.text = entity.ClassName;

        _initiative.text = entity.EntityChars.Initiative.ToString();

        _currentHealth.fillAmount = entity.Health / entity.EntityChars.MaxHealth;

        _fullName.text = entity.FullName;

        RefreshCommands();

        RefreshInventory();
    }

    private void RefreshCommands()
    {
        int i = 0;

        foreach (var slotCommand in _characterSkills)
        {
            var image = slotCommand.GetComponent<Image>();

            image.sprite = null;

            image.color = Color.white;
        }

        foreach (var command in ((Character)_entity).NativeCommands)
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

    private void RefreshInventory()
    {
        if (_inventoryPanel == null)
        {
            return;
        }

        foreach (Transform item in _inventoryPanel.GetComponentInChildren<Transform>())
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Global.inventory)
        {
            EquipmentFactory.CreateItem(item, _inventoryPanel.transform);
        }
    }
}
