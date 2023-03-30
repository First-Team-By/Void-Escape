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
    private EntityBase _entity;

    [SerializeField] private Image _image;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private List<GameObject> _characterSkills; 

    [SerializeField] private TMP_Text _entityType;

    [SerializeField] private TMP_Text _initiative;

    [SerializeField] private TMP_Text _fullName;

    [SerializeField] private EquipmentSlot _weaponSlot;

    [SerializeField] private EquipmentSlot _deviceSlot;

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
        _deviceSlot.OnEquipped += Equip;

        if (_inventoryPanel != null )
        {
            _inventorySlot.OnUnEquip += UnEquip;
        }
    }

    private void UnEquip(Equipment equipment)
    {
        if (equipment is EntityWeapon)
        {
            var characterInfo = ((Character)_entity).EntityInfo as CharacterInfo;

            characterInfo.Weapon = null;

            ((Character)_entity).Weapon = null;//оружие по умолчанию
        }

        if (equipment is EntityDevice)
        {
            var characterInfo = ((Character)_entity).EntityInfo as CharacterInfo;

            characterInfo.Device = null;

            ((Character)_entity).Device = null;//оружие по умолчанию
        }

        Global.inventory.Add(equipment);

        RefreshCommands();
    }

    private void Equip(Equipment equipment)
    {
        if (equipment is EntityWeapon)
        {
            var characterInfo = ((Character)_entity).EntityInfo as CharacterInfo;

            characterInfo.Weapon = equipment as EntityWeapon;

            ((Character)_entity).Weapon = equipment as EntityWeapon;
        }
        if (equipment is EntityDevice)
        {
            var characterInfo = ((Character)_entity).EntityInfo as CharacterInfo;

            characterInfo.Device = equipment as EntityDevice;

            ((Character)_entity).Device = equipment as EntityDevice;
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

        RefreshEquipments();

        RefreshCommands();

        RefreshInventory();
    }

    private void RefreshEquipments()
    {
        if (_weaponSlot.gameObject.transform.childCount > 0)
        {
            Destroy(_weaponSlot.gameObject.transform.GetChild(0).gameObject);
        }
        
        if (((Character)_entity).Weapon != null)
        {
            var weapon = EquipmentFactory.CreateItem(((Character)_entity).Weapon, _weaponSlot.gameObject.transform);

            weapon.transform.localPosition = Vector3.zero;
        }

        if (_deviceSlot.gameObject.transform.childCount > 0)
        {
            Destroy(_deviceSlot.gameObject.transform.GetChild(0).gameObject);
        }

        if (((Character)_entity).Device != null)
        {
            var device = EquipmentFactory.CreateItem(((Character)_entity).Device, _deviceSlot.gameObject.transform);

            device.transform.localPosition = Vector3.zero;
        }
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
