public class Blade : EntityWeapon
{
    public Blade()
    {
        Type = WeaponType.Blade;

        SlotType = SlotType.Weapon;
    }

    protected override string IconName => "equipment_blade_sprite"; 
}

