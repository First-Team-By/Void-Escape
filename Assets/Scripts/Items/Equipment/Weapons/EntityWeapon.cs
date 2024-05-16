public enum WeaponType
{
    Blade,
    Pistol,
    Scalpel
}

public abstract class EntityWeapon : Equipment
{
    public WeaponType Type { get; set; }

    protected EntityWeapon()
    {
        IsInfinite = true;
    }
}
