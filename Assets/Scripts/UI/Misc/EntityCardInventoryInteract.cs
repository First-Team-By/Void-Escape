using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCardInventoryInteract : EntityCardScript
{
    [SerializeField] private InventoryPanel _inventoryPanel;
    private bool InventoryPresent => _inventoryPanel != null;
    protected override void Init()
    {
        base.Init();

        if (InventoryPresent)
        {
            _weaponSlot.OnEquipped += Equip;
            _deviceSlot.OnEquipped += Equip;
            _armorSlot.OnEquipped += Equip;

            _weaponSlot.OnUnEquip += UnEquip;
            _deviceSlot.OnUnEquip += UnEquip;
            _armorSlot.OnUnEquip += UnEquip;

            _inventoryPanel.OnItemDrop += UnEquip;
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
}