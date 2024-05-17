public class EntityCardInventoryInteract : EntityCardScript
{
    protected override void Init()
    {
        base.Init();

        _weaponSlot.OnEquipped += Equip;
        _deviceSlot.OnEquipped += Equip;
        _armorSlot.OnEquipped += Equip;

        _weaponSlot.OnUnEquip += UnEquip;
        _deviceSlot.OnUnEquip += UnEquip;
        _armorSlot.OnUnEquip += UnEquip;
    }

    private void UnEquip(Equipment equipment)
    {
        var characterInfo = _entity as CharacterInfo;

        if (equipment is EntityWeapon)
        {
            characterInfo.Weapon = null;
        }

        if (equipment is EntityDevice)
        {
            characterInfo.Device = null;
        }

        if (equipment is EntityArmor)
        {
            characterInfo.Armor = null;
        }

       // Global.inventory.AddItem(equipment);
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

        //Global.inventory.RemoveItem(equipment);

        FillInfo(_entity);
        RefreshCommands();
    }
}
