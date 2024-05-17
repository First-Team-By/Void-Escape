public class Pistol : EntityWeapon
{
    public Pistol()
    {
        Type = WeaponType.Pistol;

        SlotType = SlotType.Weapon;
    }

    protected override string IconName => "equipment_pistol_sprite";
}