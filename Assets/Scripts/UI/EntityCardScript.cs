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
    private EntityInfo _entity;

    [SerializeField] private Image _image;

    [SerializeField] private Image _currentHealth;

    [SerializeField] private List<GameObject> _characterSkills; 

    [SerializeField] private TMP_Text _entityType;

    [SerializeField] private TMP_Text _initiative;

    [SerializeField] private TMP_Text _fullName;

    [SerializeField] private EquipmentSlot _weaponSlot;

    [SerializeField] private EquipmentSlot _deviceSlot;

    [SerializeField] private EquipmentSlot _armorSlot;

    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private InventoryPanel _inventorySlot;

    private bool InventoryPresent { get => _inventoryPanel != null; }

    public TMP_Text EntityType
    { 
        get { return _entityType; } 
        set { _entityType = value; } 
    }

    private void Start()
    {
        if (InventoryPresent)
        {
            _weaponSlot.OnEquipped += Equip;
            _deviceSlot.OnEquipped += Equip;
            _armorSlot.OnEquipped += Equip;

            _weaponSlot.OnUnEquip += UnEquip;
            _deviceSlot.OnUnEquip += UnEquip;
            _armorSlot.OnUnEquip += UnEquip;

            _inventorySlot.OnUnEquip += UnEquip;
        }
    }

    private void UnEquip(Equipment equipment)
    {
        var characterInfo = _entity as CharacterInfo;

        if (equipment is EntityWeapon)
        {
            characterInfo.Weapon = null;

            _weaponSlot.SetDefaultImage();
        }

        if (equipment is EntityDevice)
        {
            characterInfo.Device = null;

            _deviceSlot.SetDefaultImage();
        }

        if (equipment is EntityArmor)
        {
            characterInfo.Armor = null;

            _armorSlot.SetDefaultImage();
        }

        Global.inventory.Equipments.Add(equipment);

        RefreshCommands();
    }

    private void Equip(Equipment equipment)
    {

        var characterInfo = _entity as CharacterInfo;

        if (equipment is EntityWeapon)
        {
            characterInfo.Weapon = equipment as EntityWeapon;
        }

        if (equipment is EntityDevice)
        {
            characterInfo.Device = equipment as EntityDevice;
        }

        if (equipment is EntityArmor)
        {
            characterInfo.Armor = equipment as EntityArmor;
        }

        Global.inventory.Equipments.Remove(equipment);

        FillInfo(_entity);

        RefreshCommands();
    }

    public override void FillAdditional(EntityInfo entity)
    {
        _entity = entity;

        gameObject.SetActive(true);

        _image.sprite = entity.FullFaceSprite;

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
        
        if (((CharacterInfo)_entity).Weapon != null)
        {
            var weapon = EquipmentFactory.CreateItem(((CharacterInfo)_entity).Weapon, _weaponSlot.gameObject.transform);

            weapon.transform.localPosition = Vector3.zero;

            weapon.GetComponent<Image>().raycastTarget = InventoryPresent;
        }

        if (_deviceSlot.gameObject.transform.childCount > 0)
        {
            Destroy(_deviceSlot.gameObject.transform.GetChild(0).gameObject);
        }

        if (((CharacterInfo)_entity).Device != null)
        {
            var device = EquipmentFactory.CreateItem(((CharacterInfo)_entity).Device, _deviceSlot.gameObject.transform);

            device.transform.localPosition = Vector3.zero;

            device.GetComponent<Image>().raycastTarget = InventoryPresent;
        }

        if (_armorSlot.gameObject.transform.childCount > 0)
        {
            Destroy(_armorSlot.gameObject.transform.GetChild(0).gameObject);
        }

        if (((CharacterInfo)_entity).Armor != null)
        {
            var device = EquipmentFactory.CreateItem(((CharacterInfo)_entity).Armor, _armorSlot.gameObject.transform);

            device.transform.localPosition = Vector3.zero;

            device.GetComponent<Image>().raycastTarget = InventoryPresent;
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

        foreach (var item in Global.inventory.Equipments)
        {
            EquipmentFactory.CreateItem(item, _inventoryPanel.transform);
        }
    }
}
